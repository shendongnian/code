    public interface IResponse
    {
        IResult Result { get; set; }
    }
    public interface IResponse<T> : IResponse
        where T : IResult
    {
        T Result { get; set; }
    }
    public class Response<T> : IResponse<T>
        where T : IResult
    {
        public T Result { get; set; } 
        
        IResult IResponse.Result
        {
            get { return Result; }
            set { Result = (T)value; }
        }
    }
