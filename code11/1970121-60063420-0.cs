    public abstract class CustomerBase
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int CustomerTypeId { get; set; }
    }
    
    public abstract class InternalCustomer : CustomerBase
    {
    	public decimal Points { get; set; }
    }
    
    public class RegularCustomer : InternalCustomer
    {
    	public int PartnerId { get; set; }
    }
    
    public class VIPCustomer : InternalCustomer
    {
    	public string CardNo { get; set; }
    }
    
    public class ExternalCustomer : CustomerBase
    {
    }
    
    public enum CustomerType { External, Regular, VIP }
