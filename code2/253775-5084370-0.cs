    DateTime timeloop = new DateTime(0);
    timeloop = timeloop.Add(new TimeSpan(10, 00, 0)); //start at 10:00 AM
                for (int i = 0; i < 48; i++)
                {
                    string time =timeloop.ToString("hh:mm tt");           //print it as 1:30 PM
                    timeloop = timeloop.Add(new TimeSpan(0, 30, 0));      //add 30 minutes
                                   }
