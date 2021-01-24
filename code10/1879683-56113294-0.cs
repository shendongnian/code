    public class Service
    {
        public Task<MyEntity> SaveAsync()
        {
            return Task.Run(() => Save());
        }
    
        public MyEntity Save()
        {
            Thread.Sleep(2000);
            var entity = new MyEntity();
            return entity;
        }
    
        public Task SendEmailAsync()
        {
            return Task.Run(() => SendEmail());
        }
    
        public void SendEmail()
        {
            Thread.Sleep(2000);
            Console.WriteLine("The message is sent");
        }
    }
