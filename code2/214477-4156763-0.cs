public interface IDomainSpecific
{
   void DoStuff();
} 
public interface IDomainService
{
   void HelpMeDoStuff();
}
public class DomainObject1 : IDomainSpecific
{
  private readonly IDomainService _service;
  public DomainObject1( IDomainService service )
  {
    _service = service;
  }
  public DoStuff()
  {
    // Do domain specific stuff here 
    // and use the service to help
    _service.HelpMeDoStuff();
  }
}
