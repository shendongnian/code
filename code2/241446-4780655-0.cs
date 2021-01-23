    public class ConcreteWrapper : IServiceWrapper<HighLevelConversionData>
    {
    	public int StatusCode {get;set;}
    	public string StatusMessage { get; set; }
    	public List<HighLevelConversionData> ReturnedData { get; set;}
    }
    
    public class HighLevelConversionData
    {
    	public int customerID {get;set;}
    	public string customerName {get;set;}
    	public decimal amountSpent {get;set;}
    }
    
    public interface IServiceWrapper<T>
    {
    	int StatusCode { get; set; }
    	string StatusMessage { get; set; }
    	List<T> ReturnedData { get; set;}
    }
