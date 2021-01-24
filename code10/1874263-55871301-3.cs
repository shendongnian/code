    public class EmailService
    {
        [TypeFilter(typeof(LogEverything))]
        public static void Send() { }
    }
    
    GlobalJobFilters.Filters.Add(new TypeFilterAttribute(typeof(LogEverythingAttribute())));
