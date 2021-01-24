    public class ExampleController : ControllerBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ValuesController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        [HttpPost]
        public ActionResult DoStuff()
        {
            var task1 = Task.Run(async () =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var foo = scope.ServiceProvider.GetService<IFoo>();
                    await foo.Update();
                }
            });
            var task2 = Task.Run(async () =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var foo = scope.ServiceProvider.GetService<IFoo>();
                    await foo.Update();
                }
            });
            await Task.WhenAll(task1, task2);
            return Ok();
        }
    }
