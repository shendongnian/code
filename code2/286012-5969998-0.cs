    private static DateTime DateInArray = DateTime.Today;
    private static ICollection<string> UsedTodayRandoms = new List<string>();
    
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static string RandomUniqueToday()
    {
        if (! DateTime.Today.Equals(DateInArray) ) {
            UsedTodayRandoms.Clear();
            DateInArray = DateTime.Today;
        }
    
        string result = null;
        DateTime timeToGenerateUnique = DateTime.Now;
        do
        {
            result = timeToGenerateUnique.ToString("HHmmssfff");
            timeToGenerateUnique = timeToGenerateUnique.AddMilliseconds(-1);
        } while (UsedTodayRandoms.Contains(result));
        UsedTodayRandoms.Add(result);
    
        return result;
    }
