    public interface IModifiable
    {
        DateTime ModifiedDate {get; set;}
    }
    
    public static class ModifiableExtensions
    {
       public bool ModifiedToday(this IModifiable m)
       {
          return DateTime.Now.AddDays(-1).CompareTo(m.ModifiedDate) >= 0;
       } 
    
       public bool ModifiedInLastWeek(this IModifiable m)
       {
         return DateTime.Now.AddDays(-7).CompareTo(m.ModifiedDate) >= 0; 
       }
    
    }
