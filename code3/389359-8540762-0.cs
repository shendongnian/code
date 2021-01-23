    public interface IServiceAbc
    {
        ServiceResponse InvokeMyService([params]);
    }
    
    public enum ServiceResponseCase
    {
        DatabaseFailed,
        BusinessRuleViolated,
        ValidationRuleViolated
    }
    
    public class ServiceResponse
    {
        public ServiceResponseCase Case { get; internal set; }
        public string Message { get; internal set; }
    }
