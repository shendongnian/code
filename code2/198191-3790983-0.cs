        public void run()
        {
            while (processing)
            {
                //initiate action on every full hour
                if (DateTime.Now.Second == 0 && DateTime.Now.Minute == 0)
                {
                    //Do something here
                    DoSomething();
                    //Make sure we sleep long enough that datetime.now.second > 0
                    Thread.Sleep(1000);
                }
                Thread.Sleep(100);
            }
        }
