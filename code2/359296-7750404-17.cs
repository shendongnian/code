        public long WithOnlyIf(int myFlag)
        {
            Stopwatch myTimer = new Stopwatch();
            string someString = "";
            myTimer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                string height = "80%";
                string width = "80%";
                if (myFlag == 1)
                {
                    height = "60%";
                    width = "60%";
                }
                someString = "Height: " + height + Environment.NewLine + "Width: " + width;
            }
            myTimer.Stop();
            File.WriteAllText("testif.txt", someString);
            return myTimer.ElapsedMilliseconds;
        }
