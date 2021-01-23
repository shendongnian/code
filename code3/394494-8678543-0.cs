    public interface IResponse<T> where T : IResult
    {
        T Result { get; set; }
    }
    
    public class Response<T> : IResponse<T> where T : IResult
    {
        public T Result { get; set; } 
        // NO MORE COMPILER ERROR
    }
