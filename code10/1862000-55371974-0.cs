    public class MyDataRowAttribute : DataRowAttribute, ITestDataSource
    {
    	public MyDataRowAttribute(object data1) : base(data1)
    	{ }
    
    	public MyDataRowAttribute(object data1, params object[] moreData) : base(data1, moreData)
    	{ }
    
    	public new IEnumerable<object[]> GetData(MethodInfo methodInfo)
    	{
    		string[] data = base.Data.Select(x => x.ToString()).ToArray();
    		object[] arguments = new object[] { data };
    
    		return new List<object[]> { arguments };
    	}
    }
