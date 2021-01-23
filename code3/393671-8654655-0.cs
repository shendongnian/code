         // make some textboxes to ask for start date (and maybe ammount of increments)
            DateTime Date = new DateTime(2011, 11, 05);
            int steps = 7;
            for (int i = 1; i < steps; i++)
            {
                // make here a method to add a new line to datagridview
                // make use of these lines to et to your results
                string day = Date.DayOfWeek.ToString();
                int setNo = i;
                Date = Date.AddDays(7);                
            }
