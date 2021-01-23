    public class ValidationContext : IDisposable
    {
        StringBuilder Builder { get; set; }
        public ValidationContext()
        {
            Builder = new StringBuilder();
        }
        public void AddError(string message) { Builder.AppendLine(message); }
        public void Dispose()
        {
            var total = Builder.ToString().Trim();
            if (total.Length > 0)
            {
                throw new Exception(total);
            }
        }
    }
