cs
public class MyBaseComponent : ComponentBase
{
    [Inject]
    public IService AnInjectedService { get; set; }
    [Parameter]
    public string AParameter { get; set; }
    protected virtual void Update()
    {        
    }   
}
cs
@inherits MyBaseComponent
<h3>My derived component @AParamter</h3>
@code {
    protected override Update()
    {
        // code overidding my base update method
        base.Update();
    }
}
