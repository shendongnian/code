    [Binding]
        public class Hook
        {
    
            private DriverContext _driverContext;            
            public Hook(DriverContext driverContext)
            {
                _driverContext= driverContext;
            }
    
            [BeforeScenario]
            private void SetupTest()
            {
                if (_driverContext.Driver == null)
                {
                    _driverContext.StartDriver();
                }               
            }
    
     ....
        }
