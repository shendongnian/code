public class MaxFaultSizeBehavior : IEndpointBehavior
{
 private int _size;
 public MaxFaultSizeBehavior(int size)
 {
  _size = size;
 }
 public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
 {
 }
 public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
 {
  clientRuntime.MaxFaultSize = _size;
 }
 public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
 {
 }
 public void Validate(ServiceEndpoint endpoint)
 {
 }
}
