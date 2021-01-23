    public static class Extensions
    {
        public static DateTime? ToNullableDate(this String dateString)
        {
            if (String.IsNullOrEmpty((dateString ?? "").Trim()))
                return null;
            DateTime resultDate;
            if(DateTime.TryParse(dateString, out resultDate))
                return resultDate;
            
            return null;
        }
    }
    public class Test
    {
        public Test()
        {
            string dateString = null;
            DateTime? nullableDate = dateString.ToNullableDate();            
        }
    }
