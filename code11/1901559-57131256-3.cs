    class SomeClass : ISomeClass {
    
         private readonly ILogger _log;
    
         public SomeClass(ILoggerFactory loggerFactory){  // Note that we inject ILoggerFactory
               this._log = loggerFactory.CreateLogger(
                LogCategories.CreateFunctionUserCategory(this.GetType().FullName));  // Must use CreateFunctionUserCategory to create the log category name otherwise the log gets filtered out.
         }
    
         public void ExecuteMethod(){
               _log.LogInformation("This should get logged correctly.");
         }
    }
