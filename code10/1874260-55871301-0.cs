    public class EmailService
    {
        [TypeFilter(typeof(LogEverything))]
        public static void Send() { }
    }
    
    GlobalJobFilters.Filters.Add(new TypeFilter(typeof(LogEverythingAttribute())));
