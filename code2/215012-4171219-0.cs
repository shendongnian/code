    public class DaysOfTheWeek : System.Collections.IEnumerable
    {
        int[] dayflag = { 1, 2, 4, 8, 16, 32, 64 };
        string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        public string value { get; set; }
        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int i = 0; i < days.Length; i++)
            {
                if value >> i & 1 == dayflag[i] {
                    yield return days[i];
                }
            }
        }
    }
