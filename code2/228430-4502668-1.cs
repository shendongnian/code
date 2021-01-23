        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel && _session != null)
            {
                if (_session.Transaction.IsActive)
                {
                    const string msg = "OnFormClosing with active transaction.";
                    log.Error(msg);
                    throw new Exception(msg);
                }
                _session.Dispose();
            }
        }
