    public class Event
    {
        public string Title { get; set; }
        public string DateTime { get; set; }
        public string MakeJson()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("  {").AppendLine()
                .Append("    \"Title\":\"" + Meeting + "\",").AppendLine()
                .Append("    \"DateTime\":\"" + DateTime + "\"").AppendLine()
                .Append("  },").AppendLine();
            return stringBuilder.ToString();
        }
    }
Day
    public class Day
    {
        public string DayNo { get; set; }
        public List<Event> Events { get; set; }
        public string MakeJson()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\"" + DayNo + "\":[").AppendLine();    
            foreach (Event ev in Events)
            {
                stringBuilder.Append(ev.MakeJson());
            }
            
            stringBuilder.AppendLine().Append("],").AppendLine();
            return stringBuilder.ToString();
        }
    }
Month
    public class Month{
    
        public List<Day> Days { get; set; }
        public string MakeJson()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[")
                .AppendLine().Append(" {")
                .AppendLine();
            foreach (Day day in Days)
            {
                stringBuilder.Append(day.MakeJson());
            }
            stringBuilder.Append(" }")
                .AppendLine().Append("]")
                .AppendLine();
        }
    }
Once you populate the models just call MakeJson() on the month and you're good to go.
