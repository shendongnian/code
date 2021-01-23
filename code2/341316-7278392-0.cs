    public void Cancel()
            {
                lock (this)
                {
                    CancelRequest = true;
                }
            }
