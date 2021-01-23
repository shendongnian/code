     void LongRunningOperation()
        {
            int r = 5000;
            int sR = 20;
            List<TimeSpan> timeSpanList = new List<TimeSpan>();
            for (int i = 0; i < r; i++)
            {
                DateTime n = DateTime.Now; // Gets start time of this iteration.
                for (int x = 0; x < sR; x++)
                {
                     // DOING WORK HERE       
                }
                timeSpanList.Add(DateTime.Now - n); // Gets the length of time of iteration and adds it to list.
                double avg = timeSpanList.Select(x => x.TotalSeconds).Average(); // Use LINQ to get an average of the TimeSpan durations.
                TimeSpan timeRemaining = DateTime.Now.AddSeconds((r - i) * avg) - DateTime.Now;
                // Calculate time remaining by taking the total number of rows minus the number of rows done multiplied by the average duration.
                UpdateStatusLabel(timeRemaining);
            }
        }
