        public class employee    
        {
           // This is "backing field" for hourly wage
           private double _hourlyWage;
           public double hourlyWage
           {
               get
               {
                   return _hourlyWage;
               }
               set
               {
                   // Set both _hourlyWage and weekly wage at once
                   _hourlyWage = value;
                   weeklyWage = _hourlyWage * 40;
               }
           }
           // Public for get, private for set
           public double weeklyWage { get; private set; }
        }
