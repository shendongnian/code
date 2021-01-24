    public class ApiResult
    {
        public string Result { get; set; }
        public ApiDevice[] Device { get; set; }
    
        public ApiResult(string result, ApiDevice[] devices) {
            Result = result;
            Device = devices;
        }
    }
