        public static void ExtractNumbers()
        {
            string test = "main(volatage1, voltage2, current)   0,017   0,77    v   100  I";
            var tokens = test.Split(' ');
            foreach(string s in tokens)
            {
                try
                {
                    double d = Convert.ToDouble(s);
                }
                catch (FormatException)
                {
                    //
                }
            }
        }
