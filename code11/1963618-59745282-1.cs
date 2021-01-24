    public class MyController : ControllerBase
    {
            private readonly AppSettings  _appsettings;
            public MyController(AppSettings appsettings) {
                _appsettings = appsettings;
            }
    
            public async Task<IActionResult> Method()
            {
                var setting = _appsettings.cacheDirPath;
            }
    }
