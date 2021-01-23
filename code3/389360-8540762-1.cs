    public interface IServiceAbc
    {
        ServiceResponse InvokeMyService([params]);
    }
    
    public enum ResponseScenario
    {
        Success,
        DatabaseFailed,
        BusinessRuleViolated,
        ValidationRuleViolated
    }
    
    public class ServiceResponse
    {
        public ResponseScenario Scenario { get; internal set; }
        public string Message { get; internal set; }
    }
