    public class ReportBase<TReport>
    {
    	public List<TReport> Reports { get; set; }
    
    	List<Type> possibleTypes = new List<Type> {typeof(int), typeof(double)};
    	
    	public IEnumerable<double> CalculateSum()
    	{
    		foreach (PropertyInfo element in typeof(TReport).GetProperties())
    		{
    			if (possibleTypes.Contains(element.PropertyType))
    			{
    				yield return Reports.Sum(x => Convert.ToDouble(element.GetValue(x)));
    			}
    		}
    	}
    }
