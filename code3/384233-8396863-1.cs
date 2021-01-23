    public void StartDSNTimers()
        {
            _tmr1 = new Timer(CheckMessages, dsn1, 0, 60000);
            _tmr2 = new Timer(CheckMessages, dsn2, 0, 60000);
            _tmr3 = new Timer(CheckMessages, dsn3, 0, 60000);
        }
        private void CheckMessages(object obj)
        {
            //Logic
        }
