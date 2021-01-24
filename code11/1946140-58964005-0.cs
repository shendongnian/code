cs
public class MyBaseComponent : ComponentBase
{
    [Inject]
    public IService AnInjectedService { get; set; }
    [Parameter]
    public string AParameter { get; set; }
}
cs
@inherits MyBaseComponent
<h3>My derived component @AParamter</h3>
