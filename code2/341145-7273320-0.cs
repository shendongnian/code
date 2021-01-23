        public delegate void TracertCallbacHandler(Tracert sender, TracertNode newNode);
        public class Tracert
        {
            public event TracertCallbacHandler NewNodeFound;
            public event EventHandler TracertCompleted;
            public void Trace()
            {
                ....
            }
            // This function gets called in tracert thread\async method.
            private void FunctionCalledInThreadWhenPingCompletes(TracertNode newNode)
            {
                var handler = this.NewNodeFound;
                if (handler != null)
                    handler(this, newNode);
            }
            // This function gets called in tracert thread\async methods when everything ends.
            private void FunctionCalledWhenEverythingDone()
            {
                var handler = this.TracertCompleted;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
