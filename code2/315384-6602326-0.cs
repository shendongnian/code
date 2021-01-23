    public event CancelEventHandler DeleteSnapshotStarted;
    public event AsyncCompletedEventHandler DeleteSnapshotCompleted;
    public void DeleteSnapshot(Guid documentId, Action<Exception> callback)
    {
        if (!this.Snapshots.Where(x => x.DocumentId == documentId).Any())
            throw new Exception("Snapshot not found; ensure LoadSnapshots()");
    
        // define action
        var _Action = new Action(() =>
        {
            // preview
            bool _Cancelled = false;
            if (DeleteSnapshotStarted != null)
            {
                CancelEventArgs _CancelArgs = new CancelEventArgs { };
                DeleteSnapshotStarted(this, _CancelArgs);
                if (_CancelArgs.Cancel)
                {
                    _Cancelled = true;
                }
            }
    
            if (!_Cancelled) {
                // execute
                Exception _Error = null;
                try
                {
                    Proxy.CoreService.DeleteSnapshot(documentId);
                    LoadSnapshots(null);
                }
                catch (Exception ex) { _Error = ex; }
            }
    
            // complete
            if (DeleteSnapshotCompleted != null)
            {
                AsyncCompletedEventArgs _CompleteArgs = 
                    new AsyncCompletedEventArgs(_Error, _Cancelled, null);
                DeleteSnapshotCompleted(this, _CompleteArgs);
            }
    
            // bubble error
            if (_Error != null)
                throw _Error;
        });
    
        // run it
        if (callback == null) { _Action(); }
        else
        {
            using (BackgroundWorker _Worker = new BackgroundWorker())
            {
                _Worker.DoWork += (s, arg) => { _Action(); };
                _Worker.RunWorkerCompleted += (s, arg) => { callback(arg.Error); };
                _Worker.RunWorkerAsync();
            }
        }
    }
