cs
public class ApiExplorerIgnores : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (action.Controller.ControllerName.Equals("Pwa"))
            action.ApiExplorer.IsVisible = false;
    }
}
2. Add following code to method **ConfigureServices** in **Startup.cs**
cs
services.AddMvc(c => c.Conventions.Add(new ApiExplorerIgnores()))
This should hide the **PwaController** from _ApiExplorer_ which is used by _Swashbuckle_.
