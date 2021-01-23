    public interface IModifiable
    {
       public DateTime ModifiedDate {get; set;}
    }
    
    public interface IDeletable
    {
       public DateTime DeletionDate {get; set;}    
    }
    
    
    public static class SomeExtentions
    {
    	public static bool IsModifiedToday(this IModifiable modifiable)
    	{
    		return DateTime.Now.AddDays(-1).CompareTo(modifiable.ModifiedDate) >= 0;
    	} 
    
    	public static bool IsModifiedInLastWeek(this IModifiable modifiable)
    	{
    		return DateTime.Now.AddDays(-7).CompareTo(modifiable.ModifiedDate) >= 0;
    	}	
    	public static bool IsDeleted(this IDeletable deletable)
    	{
    		return deletable.DeletionDate != default(DateTime);
    	}
    }
