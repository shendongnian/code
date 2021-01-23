        void tmrPing (object state) {
            foreach (var ctx in _clientCtxList)
            {
                // todo: catch exceptions and remove client context 
                //       from list in case of failure
                ctx.GetCallbackChannel<IMyCallbackContract>().Ping();
            }
 
            // restart timer
            _timer.Change(10000, Timeout.Infinite);
        }
