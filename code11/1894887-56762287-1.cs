    public class BaseResponseDTO<T>
    {
        public bool Succeed { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
        public int? ErrorCode { get; set; }
    }
