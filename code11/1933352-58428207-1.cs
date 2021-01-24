          TimeSpan[] hours = new[] 
          { new TimeSpan(10, 35, 50),
            new TimeSpan(10, 36, 48),
            new TimeSpan(10, 41, 48),
            new TimeSpan(10, 47, 58),
            new TimeSpan(10, 49, 14),
            new TimeSpan(11, 22, 15),
            new TimeSpan(11, 24, 18),
            new TimeSpan(11, 25, 25), };
          int groupID = -1;
          var result = hours.OrderBy(h => h).Select((item, index) =>
            {
              if (index == 0 || (!(Math.Abs(hours[index - 1].Subtract(item).TotalMinutes) <= 5)))
                ++groupID;
    
              return new { group = groupID, item = item };
            }).GroupBy(item => item.group);
    
        
