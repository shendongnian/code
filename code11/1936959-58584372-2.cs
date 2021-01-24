        public class employee    
        {
           // This is "backing field" for hourly wage
           private double _hourlyWage;
           // And this is actual property, where business logic happens
           public double hourlyWage
           {
               get
               {
                   return _hourlyWage;
               }
               set
               {
                   // Set both _hourlyWage and weeklyWage at once
                   _hourlyWage = value;
                   weeklyWage = _hourlyWage * 40;
               }
           }
           // Public for get, private for set (r
           public double weeklyWage { get; private set; }
        }
