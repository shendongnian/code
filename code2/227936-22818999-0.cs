    public class DayOfWeekComparer : IComparer<DayOfWeek>
    {
        public static int Rank(DayOfWeek firstDayOfWeek, DayOfWeek x)
        {
            return (int)x + (x < firstDayOfWeek ? 7 : 0);
        }
        public static int Compare(DayOfWeek firstDayOfWeek, DayOfWeek x, DayOfWeek y)
        {
            return Rank(firstDayOfWeek, x).CompareTo(Rank(firstDayOfWeek, y));
        }
        DayOfWeek firstDayOfWeek;
        public DayOfWeekComparer(DayOfWeek firstDayOfWeek)
        {
            this.firstDayOfWeek = firstDayOfWeek;
        }
        public int Compare(DayOfWeek x, DayOfWeek y)
        {
            return DayOfWeekComparer.Compare(this.firstDayOfWeek, x, y);
        }
    }
