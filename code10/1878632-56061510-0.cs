    public IActionResult<MyCustomResponseObject> GetInfo([FromBody] InfoModel info)
    public class MyCustomResponseObject
    {
        public string Message { get; set; }
        public object Content { get; set; }
        public enum State { get; set; }
    }
