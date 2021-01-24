csharp
public class DialogsSingleton
{
  private readonly IServiceProvider services;
  public DialogsSingleton(IServiceProvider services)
  {
    this.services = services;
  }
  public void DomeSomethingRequiringDbContext()
  {
    using (var scope = this.services.CreateScope())
    {
      var scopedService = scope.ServiceProvider.GetRequiredService<GretaDBContext>();
      // Use the scoped service
    }
  }
}
