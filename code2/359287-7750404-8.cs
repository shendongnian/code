        public long WithIfAndElse(int myFlag)
        {
            Stopwatch myTimer = new Stopwatch();
            string someString = "";
            myTimer.Start();
            for (int i = 0; i < 1000000; i++)
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
                someString = "Height: " + height + Environment.NewLine + "Width: " + width;
            }
            myTimer.Stop();
            File.WriteAllText("testifelse.txt", someString);
            return myTimer.ElapsedMilliseconds;
        }
