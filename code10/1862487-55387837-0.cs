    using System;
    using BenchmarkDotNet.Attributes;
    public static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<CalculateTotalDaysBenchmarks>();
        }
    }
    [ClrJob()]
    [CoreJob()]
    public class CalculateTotalDaysBenchmarks
    {
        private static readonly DateTime TestTime = new DateTime(2009, 6, 19, 18, 0, 0);
        [Benchmark(Baseline = true)]
        public decimal Method1_DayPlusTotalHoursDivided()
        {
            return (decimal) (TestTime.Day + TestTime.TimeOfDay.TotalHours / 24);
        }
        [Benchmark()]
        public decimal Method2_DayPlusTicksDivided()
        {
            return TestTime.Day + (decimal) TestTime.TimeOfDay.Ticks / TimeSpan.TicksPerDay;
        }
        [Benchmark()]
        public decimal Method3_SubtractLastDayOfPreviousMonth()
        {
            DateTime lastDayOfPreviousMonth = new DateTime(TestTime.Year, TestTime.Month, 1).AddDays(-1);
            return (decimal) (TestTime - lastDayOfPreviousMonth).TotalDays;
        }
        [Benchmark()]
        public decimal Method4_NewTimeSpan()
        {
            return (decimal) new TimeSpan(TestTime.Day, TestTime.Hour, TestTime.Minute, TestTime.Second, TestTime.Millisecond).TotalDays;
        }
    }
