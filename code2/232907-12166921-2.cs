    using System;
    using System.Globalization;
    using FluentAssertions;
    using NUnit.Framework;
    
    //...Namespace, test fixture class, etc ...
    
            [Test]
            public void GetMetricsTimesBetween_ReturnsCorrectRange() {
               DateTime startDate = new DateTime(2012, 8, 1);
               DateTime endDate = new DateTime(2012, 8, 31);
               
               var cal = new GregorianCalendar();
    
               int startWeekNumber = cal.GetWeekOfYear(startDate, 
                                                       CalendarWeekRule.FirstDay,                                      
                                                       DayOfWeek.Thursday);
               int endWeekNumber = cal.GetWeekOfYear(endDate, 
                                                    CalendarWeekRule.FirstDay,  
                                                    DayOfWeek.Thursday);
               int numberOfWeeksInRange = endWeekNumber - startWeekNumber;
    
               numberOfWeeksInRange.Should().Be(5);
            }
