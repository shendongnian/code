    public interface IResponse
    {
        IResult Result { get; set; }
    }
    public class Response<T> : IResponse
        where T : IResult
    {
        public T Result { get; set; } 
        
        IResult IResponse.Result
        {
            get { return Result; }
            set { Result = (T)value; }
        }
    }
