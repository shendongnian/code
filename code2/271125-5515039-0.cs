    double 30daysval;
        double 60daysval;
        foreach (Purchases purch in Purchases)
        {
              TimeSpan span = DateTime.Now - purch.Timestamp;
              if (span.Days <= 30)
              {
                    30daysval += purch.Value;
                    //Add a row to the grid
              }
              else if (span.Days <= 60)
              {
                    60daysval += purch.Value
                    //Add a row to the grid
              }
        }
