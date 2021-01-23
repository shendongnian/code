    public interface IController<T> where T : DataTransferBase {}
    public class Controller<T> : IController<T> where T : DataTransferBase
    {
        /// <summary>Initializes a new instance of the ProductController class.</summary>
        public Controller(ILogger<T> logger)
        {
            
        }
        public virtual List<T> GetItems()
        {
            return new List<T>();
        }
    }
