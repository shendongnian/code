        public long WithIfAndElse(int myFlag)
        {
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            for (int i = 0; i < 1000000000; i++)
            {
                string height;
                string width;
                if (myFlag == 1)
                {
                    height = "60%";
                    width = "60%";
                }
                else
                {
                    height = "80%";
                    width = "80%";
                }
            }
            myTimer.Stop();
            return myTimer.ElapsedMilliseconds;
        }
