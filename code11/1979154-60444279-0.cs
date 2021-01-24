    ```csharp
    public class MyController : Controller
    {
        private IServiceProvider _sp;
        public MyController(IServiceProvider sp)
        {
            this._sp = sp;
        }
    }
    ```
    and when you want a small scope, you can create it as below:
    ```
    public IActionResult MyActoin()
    {
        // create a more small scope
        using (var scope = this._sp.CreateScope())
        {
            var sp = scope.ServiceProvider;
            // now you get the services from this small scope
            var svc1 = sp.GetRequiredService<MyService1>();
            var svc2 = sp.GetRequiredService<MyService2>();
            //...
        }
        return new JsonResult("it works");
    }
    ```
