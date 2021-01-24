    public interface IHierarchy<T>
    {
    	List<T> Children { get; set; }
    }
    
    public class Company : IHierarchy<Company>
    {
    	public int Id { get; set; }
    
    	public string Name { get; set; }
    
    	public int? ParentId { get; set; }
    
    	public List<Company> Subsidiaries { get; set; } = new List<Company>();
    
    	List<Company> IHierarchy<Company>.Children
    	{
    		get => this.Subsidiaries;
    		set => this.Subsidiaries = value;
    	}
    }
    
    public static class Extensions
    {
    
    	public static List<T> Sort<T, K>(this List<T> list, Func<T, K> sortSelector) where T : IHierarchy<T>
    	{
    		List<T> result = list.OrderBy(sortSelector).ToList();
    
    		foreach (T listItem in list)
    		{
    			if (listItem.Children.Count > 0)
    				listItem.Children = Sort<T, K>(listItem.Children, sortSelector);
    		}
    		return result;
    	}
    }
