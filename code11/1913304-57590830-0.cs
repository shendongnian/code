public class Response<T>
{
        public Response(bool defalut = false)
        {
            IsSuccess = defalut;
            Message = "";
        }
        public Response(string message)
        {
            IsSuccess = false;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
}
