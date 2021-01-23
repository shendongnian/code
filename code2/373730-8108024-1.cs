    using System;
    using System.Collections.Generic;
    
    namespace Whatever
    {
      public struct DataPoint
      {
        private DateTime time;
        private int value;
        
        public DataPoint(DateTime time, int value)
        {
          this.time = time;
          this.value = value;
        }
        
        public DateTime Time
        {
          get { return this.time; }
        }
        
        public int Value
        {
          get { return this.value; }
        }
        
        public override string ToString()
        {
          return string.Format("{0:D2}/{1}: {2}", this.time.Month, this.time.Year, this.value);
        }
      }
    
      public static class Program
      {
        public static void Main()
        {
          // List of the datapoints, e.g. loaded from a database
          var dataPoints = new List<DataPoint>();
          dataPoints.Add(new DataPoint(new DateTime(2010, 11, 1), 10));
          dataPoints.Add(new DataPoint(new DateTime(2011,  2, 1), 20));
          dataPoints.Add(new DataPoint(new DateTime(2011,  3, 1), 30));
          dataPoints.Add(new DataPoint(new DateTime(2011,  6, 1), 40));
          dataPoints.Add(new DataPoint(new DateTime(2011,  9, 1), 50));
          dataPoints.Add(new DataPoint(new DateTime(2011, 12, 1), 60));
          dataPoints.Add(new DataPoint(new DateTime(2012,  2, 1), 70));
          
          // Endpoints of the measurement interval
          var begin = new DateTime(2010, 9, 1);
          var end   = new DateTime(2012, 4, 1);
          
          // Check each month and insert missing datapoints
          var time = begin;
          var i = 0;
          while (time <= end)
          {
            if (i < dataPoints.Count)
            {
              if (time < dataPoints[i].Time)
              {
                var dataPoint = new DataPoint(time, 0);
                dataPoints.Insert(i, dataPoint);
              }
            }
            else
            {
              var dataPoint = new DataPoint(time, 0);
              dataPoints.Add(dataPoint);
            }
            ++i;
            time = time.AddMonths(1);
          }
          
          // Print list
          foreach (var dataPoint in dataPoints)
            Console.WriteLine(dataPoint);
        }
      } 
    }
