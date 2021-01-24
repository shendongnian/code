    public class Wrapper<T>
    {
        public T Data { get; set; }
        public string Status { get; set; }
        public DateTime CallDate { get; set; }
        public Wrapper(T data) { this.Data = data ; }
    }
