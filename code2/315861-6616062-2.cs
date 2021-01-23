    class Communicator {
        private ISynchronizeInvoke sync;
        private Action syncAction;
        public void SetSync(ISynchronizeInvoke sync, Action action) {
            this.sync = sync;
            this.syncAction = action;
        }
        protected virtual void OnDataReceived(...) {
            if (!sync.InvokeRequired) {
                syncAction();
            }
            else {
                object[] args = new object[] { };
                sync.Invoke(action, args);
            }
        }
    }
