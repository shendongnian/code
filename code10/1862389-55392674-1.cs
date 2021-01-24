cs
public class ServiceA : IServiceA {
    public void OperationA() {
        Service.Instance.Operation()
    }
}
and the same for `ServiceB`. Once I did that I changed my .svc files to generate WSDL only for the Contract implementations and not main service.
