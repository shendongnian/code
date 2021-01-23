    public class Response<T> : IResponse
        where T : IResult
    {
        public T Result { get; set; }
        // COMPILER ERROR: Property 'Result' cannot be implemented property from interface 'IResponse'. Type should be 'IResult'. 
    
        IResult IResponse.Result
        {
            get { return this.Result; }
            set { this.Result = (T)value; }
        }
    } 
