public class MemberInfoController : Controller
{
      IMemberDetails details;
      public MemberInfo(IMemberDetails det)
      {
          details = det;
      }
}
    // further code
**Also a few notes**
If you wont to use injected dependency outside of controller you can just pass it with a function.
Like this
    // Here was DependencyInjection
    
    public IActionResult res()
    {
       MyClass class = new MyClass();
       class.SomeFunc(details);
    }
