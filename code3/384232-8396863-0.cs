    public void Start()
        {
            _tmr = new Timer(CheckMessages, null, 10000, 60000);//create timers dynamically for different DSN's
        }
        private void CheckMessages(object obj)
        {
            //Logic
        }
