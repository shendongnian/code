    public class ReportBase<TReport>
    {
    
    	public List<TReport> Reports { get; set; }
    	
    	public IEnumerable<int> CalculateSum()
    	{
    		foreach (var element in typeof(TReport).GetProperties())
    		{
    			if (element.PropertyType.Name == typeof(int).Name)
    			{
    				yield return Reports.Sum(x => (int)element.GetValue(x));
    			}
    		}
    	}
    }
