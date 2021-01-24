    class MyClass
    {
    ILogger _firstLogger;
    ILogger _secondLogger;
    
    public MyClass(ILoggerFactory factory)
            {
                _firstLogger = factory.CreateLogger($"{GetType().ToString()}.ActionResult.First");
                _secondLogger = factory.CreateLogger($"{GetType().ToString()}.ActionResult.Second");
            }
    
    public IActionResult First()
            {
                ///to log the information into C:/nlog-First-*.txt
                _firstLogger.LogInformation("Hello First");
                return View();
            }  
    public IActionResult Second()
            {
                ///to log the information into C:/nlog-Second-*.txt
                _firstLogger.LogInformation("Hello Second");
                return View();
            }
    }
