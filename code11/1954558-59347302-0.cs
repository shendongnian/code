    public class MyDbUpdateConcurrencyException : DbUpdateException
    {
        public MyDbUpdateConcurrencyException(string message, IReadOnlyList<IUpdateEntry> entries) : base(message, (Exception)null)
        {
        }
    }
