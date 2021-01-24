cs
public class ServiceA : IServiceA {
    public void OperationA() {
        Service.Instance.Operation()
    }
}
and the same for `ServiceB`.
