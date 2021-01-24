    class SomeClass
    {
        public ILogger _logger;
    
        public SomeClass(ILogger logger)
        {
             this._logger = logger;
        }
        public double SomeOperation(IItem item)
        {
    		_logger.Log("SomeOperation");
             return item.Calories + item.Fats + item.Proteins;
        }
    }
