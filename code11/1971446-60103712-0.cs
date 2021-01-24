    public class Request<T> : IRequest<T> where T : Form
    {
        public T Form { get; set; }
    }
    public interface IRequest<out T> 
    {
        public T Form
        {
            get;
        }
    }
