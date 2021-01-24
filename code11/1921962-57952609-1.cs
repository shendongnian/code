    int[] pageIds = getIdsOfPages<MyClass>(idList.AsQueryable(), page => page.PageId ?? -1, id => id > -1);
    public static List<MyClass> idList = new List<MyClass>();
    public class MyClass
    {
    	public int? PageId { get; set; }
    }
