        public long WithOnlyIf(int myFlag)
        {
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            for (int i = 0; i < 1000000000; i++)
            {
                string height = "80%";
                string width = "80%";
                if (myFlag == 1)
                {
                    height = "60%";
                    width = "60%";
                }
            }
            myTimer.Stop();
            return myTimer.ElapsedMilliseconds;
        }
       
