    public class Response
    {
        public bool flag { get; set; }
        public string message { get; set; }
        public Permisions result { get; set; }
    }
    public class Permisions
    {
        public bool ServicePermission { get; set; }
        public bool UserGroupPermission { get; set; }
    }
    var response = JsonSerializer.DeserializeFromString<Response>(responseFromServer);
    Console.WriteLine(response.flag + ":" + response.result.ServicePermission);
