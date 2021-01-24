    public class MyDbUpdateConcurrencyException : DbUpdateException
    {
        public MyDbUpdateConcurrencyException(string message) : base(message, (Exception)null)
        {
        }
    }
