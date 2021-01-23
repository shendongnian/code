            private void A(object state)
        {
            // does one thing
        }
        private void B(object state)
        {
            // does a different thing
        }
        private void C(int i)
        {
            switch (i)
            {
                case 1:
                    D(new System.Threading.WaitCallback(A));
                    break;
                case 2:
                    D(new System.Threading.WaitCallback(B));
                    break;
                default:
                    break;
            }
        }
        private void D(System.Threading.WaitCallback worker)
        { 
            System.Threading.ThreadPool.QueueUserWorkItem(worker);
        }
