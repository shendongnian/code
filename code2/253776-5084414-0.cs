            DateTime time = new DateTime(2011,02,22,10,0,0);
            List<String> times = new List<string>();
            for (int i = 0; i < 48; i++)
            {
                time = time.AddMinutes(30);
                times.Add(time.ToString());
            }
