        System.Threading.Timer _timer;
        void Startup() {
            // call my function in 10 seconds
            _timer = new System.Threading.Timer(
                            tmrPing, null, 10000, Timeout.Infinte);
        }
