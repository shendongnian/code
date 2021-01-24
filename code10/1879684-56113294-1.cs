    public class SomeController
    {
        private readonly Service _service;
    
        public SomeController()
        {
            _service = new Service();
        }
    
        public MyEntity AddRecord()
        {
            var resultTask = _service.SaveAsync();
            _service.SendEmailAsync();
    
            return resultTask.Result;
        }
    
        public async Task<MyEntity> AddRecord2()
        {
            var resultTask = _service.SaveAsync();
    
            _service.SendEmailAsync();
    
            //var result = await resultTask;
            //return result;
    
            return await resultTask;
        }
    }
