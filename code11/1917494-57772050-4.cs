    public class ReportBase<TReport>
    {
    
    	public List<TReport> Reports { get; set; }
    	
    	public IEnumerable<int> CalculateSum()
    	{
    		foreach (var element in typeof(TReport).GetProperties())
    		{
    			if (element.PropertyType == typeof(int))
    			{
    				yield return Reports.Sum(x => (int)element.GetValue(x));
    			}
    		}
    	}
    }
