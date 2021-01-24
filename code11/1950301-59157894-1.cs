        public static void ExtractNumbers()
        {
            string test = "main(volatage1, voltage2, current)   0,017   0,77    v   100  I";
            var tokens = test.Split(new char[] { ' ', '\t'} );
            foreach (string s in tokens)
            {
                double d;
                Double.TryParse(s, out d);
            }
        }
