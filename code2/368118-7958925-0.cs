    public struct MonthDay : IEquatable<MonthDay>
    {
        private readonly DateTime dateTime;
        public MonthDay(int month, int day)
        {
            dateTime = new DateTime(2000, month, day);
        }
        public MonthDay AddDays(int days)
        {
            DateTime added = dateTime.AddDays(days);
            return new MonthDay(added.Month, added.Day);
        }
        // TODO: Implement interfaces, equality etc
    }
