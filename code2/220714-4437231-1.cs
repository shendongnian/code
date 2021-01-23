    public class ReversalSender
    {
        private bool _running = true;
        private ManualResetEvent _reset = new ManualResetEvent(false);
        public void Run()
        {
            while (_running)
            {
                _reset.WaitOne();
                //We now need to grab all the waiting reversals
                ReversalsDataContext db = new ReversalsDataContext();
                var reversals = db.FiReversals.Where(r => r.Status == Reversal.ReversalStatus.WAITING_TO_SEND);
                if (reversals.Any())
                {
                    foreach (var rev in reversals)
                    {
                        if (_running)
                            SendReversal(rev);
                    }
                }
                db.SubmitChanges();
            }
        }
        private void SendReversal(FiReversal rev)
        {
           .....
        }
        public void Signal()
        {
            _reset.Set();
        }
        public void Stop()
        {
            _running = false;
        }
    }
