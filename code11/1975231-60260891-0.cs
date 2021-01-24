cs
[Parameter] public string InlineClass { get; set; }
...
protected RazorHtmlComponent()
{
    ClassMapper = new DomDefinitionMapper(InlineClass);
}
The parameter is not yet set. It'll be when `OnInitialized` or `OnInitializedAsync` is called.  
And your `RazorHtmlComponent` must derived from [`ComponentBase`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(Microsoft.AspNetCore.Components.ComponentBase);k(SolutionItemsProject);k(DevLang-csharp)%26rd%3Dtrue&view=aspnetcore-3.1)
cs
public abstract class RazorHtmlComponent : ComponentBase, IRazorHtmlComponent
{
  [Parameter] public string InlineClass { get; set; }
  public DomDefinitionMapper ClassMapper { get; }
  ...
  protected override void OnInitialized()
  {
    ClassMapper = new DomDefinitionMapper(InlineClass);
  }
