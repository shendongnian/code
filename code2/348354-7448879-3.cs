    private void ExecuteWorker() {
        while (true) {
            _pauseEvent.WaitOne(Timeout.Infinite);
            //This kills our process
            if (_shutdownEvent.WaitOne(0)) {
               break;
            }
            if (!_worker.IsReadyToExecute) {
                //sleep 5 seconds before checking again. If we go any longer we keep our service from shutting down when it needs to.
                _shutdownEvent.WaitOne(5000);
                continue;
            }
            DoWork();
        }
    }
