    using System;
    using System.Collections.Generic;
    
    public class StatisticsFilter 
    {
        private String someString1;
        private String someString2;
    
        public StatisticsFilter(string x, string y)
        {
            this.someString1 = x;
            this.someString2 = y;
        }
    
        public override string ToString()
        {
            return string.Format("{0}-{1}xyz", someString1, someString2);
        }
    
        public override bool Equals(object obj)
        {            
            return obj.ToString().Equals(ToString());
        }
    
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
    
    class Test
    {
        static void Main()
        {
            var dict = new Dictionary<StatisticsFilter, int>();
            
            var sf1 = new StatisticsFilter("hello", "there");
            var sf2 = new StatisticsFilter("hello", "there");
            
            dict[sf1] = 10;
            Console.WriteLine(dict.ContainsKey(sf2)); // Prints true
        }
    }
