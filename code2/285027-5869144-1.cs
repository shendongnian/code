        System.Threading.Timer timer = new System.Threading.Timer(OnTimerEllapsed,new object(),0,2000);
        private void OnTimerEllapsed(object state)
        {
            if(!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(LoadImages);
            }
        }
        private void LoadImages()
        {
            // load images here
        }
