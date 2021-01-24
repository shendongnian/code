    public class ApiResult
    {
        public string Result { get; set; }
        public List<ApiDevice> Device { get; set; }
    
        public ApiResult() {
            Device = new List<ApiDevice>();
        }
    }
