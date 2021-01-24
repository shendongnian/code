    public class MyBusinessLogic()
    {
        private ISleepService _sleepService;
        public MyBusinessLogic(ISleepService sleepService)
        {
            _sleepService = sleepSerivce;
        }
    
        public void MyBusinessMethod()
        {
            // your code
            _sleeService.Sleep(20000);
            // more code
        }
    }
