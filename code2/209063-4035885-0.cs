    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    namespace DayOfWeekUtilities
    {
        public static class DayOfWeekHelpers
        {
            /// <summary>
            /// returns all days of the week, inclusive, from day1 to day2
            /// </summary>
            public static IEnumerable<DayOfWeek> GetDaysBetweenInclusive(DayOfWeek day1,
                                                                         DayOfWeek day2)
            {
                var final = (int)day2;
                if(day2 < day1)
                {
                    final += 7;
                }
                var curr = (int)day1;
                do
                {
                    yield return (DayOfWeek) (curr%7);
                    curr++;
                } while (curr <= final);
            }
            /// <summary>
            /// returns true if the provided date falls on a day of the 
            /// week between day1 and day2, inclusive
            /// </summary>
            public static bool IsDayOfWeekBetween(this DateTime date,
                                                  DayOfWeek day1,
                                                  DayOfWeek day2)
            {
                return GetDaysBetweenInclusive(day1, day2).Contains(date.DayOfWeek);
            }
        }
        [TestFixture]
        public class Tests
        {
            [Test]
            public void Test()
            {
                Assert.IsTrue(new DateTime(2010, 10, 22).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsTrue(new DateTime(2010, 10, 23).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsTrue(new DateTime(2010, 10, 24).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsFalse(new DateTime(2010, 10, 25).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsFalse(new DateTime(2010, 10, 26).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsFalse(new DateTime(2010, 10, 27).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsFalse(new DateTime(2010, 10, 28).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsTrue(new DateTime(2010, 10, 29).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Sunday));
                Assert.IsTrue(new DateTime(2010, 10, 22).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 23).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 24).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 25).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 26).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 27).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 28).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 29).IsDayOfWeekBetween(DayOfWeek.Friday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 22).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 23).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsFalse(new DateTime(2010, 10, 24).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 25).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 26).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 27).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 28).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 29).IsDayOfWeekBetween(DayOfWeek.Monday, DayOfWeek.Friday));
                Assert.IsTrue(new DateTime(2010, 10, 22).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsTrue(new DateTime(2010, 10, 23).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsTrue(new DateTime(2010, 10, 24).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsTrue(new DateTime(2010, 10, 25).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsTrue(new DateTime(2010, 10, 26).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsFalse(new DateTime(2010, 10, 27).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsTrue(new DateTime(2010, 10, 28).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
                Assert.IsTrue(new DateTime(2010, 10, 29).IsDayOfWeekBetween(DayOfWeek.Thursday, DayOfWeek.Tuesday));
            }
        }
    }
