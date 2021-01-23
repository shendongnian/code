    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication17
    {
        class Program
        {
          const double HoursPerDay   = 24;
          const double MinsPerHour   = 60;
          const double SecsPerMin    = 60;
          const double MSecsPerSec   = 1000;
          const double MinsPerDay    = HoursPerDay * MinsPerHour;
          const double SecsPerDay    = MinsPerDay * SecsPerMin;
    
            static double SpanOfNowAndThen(Double ANow, Double AThen)
            {
              if (ANow < AThen)
                return AThen - ANow;
              else
                return ANow - AThen;
            }
    
    
            static double SecondSpan(Double ANow, Double AThen)
            {
             return  SecsPerDay * SpanOfNowAndThen(ANow, AThen);
            }
    
            static int SecondsBetween(DateTime ANow, DateTime AThen)
            {
              return (int)Math.Truncate(SecondSpan(ANow.ToOADate(), AThen.ToOADate()));
            }
    
            static void Main(string[] args)
            {
                TimeSpan span ;            
                span = DateTime.Parse("16/02/2009 23:25:34").Subtract(DateTime.Parse("1/01/2005 00:00:00"));
                Console.WriteLine(span.TotalSeconds);//returns 130289134
                Console.WriteLine(SecondsBetween(DateTime.Parse("16/02/2009 23:25:34"), DateTime.Parse("1/01/2005 00:00:00")));//returns 130289133
    
                span = DateTime.Parse("16/11/2011 23:25:43").Subtract(DateTime.Parse("1/01/2005 00:00:00"));
                Console.WriteLine(span.TotalSeconds);//returns 216948343
                Console.WriteLine(SecondsBetween(DateTime.Parse("16/11/2011 23:25:43"), DateTime.Parse("1/01/2005 00:00:00")));//returns 216948343
    
                Console.ReadKey();
            }
        }
    }
