        public class employee
        {                
                public double hourlyWage{get;set;}    
                public double weeklyWage { get { return hourlyWage * 40; } }
                // "modern" getter syntax would look this way:
                // public double weeklyWage => hourlyWage * 40;
                // Still used "old" syntax for being more expressive.
                // The choice is yours.
        }
