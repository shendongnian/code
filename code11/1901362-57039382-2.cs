public class Id{
    public object gt { get; set; }
}
public class Selector{
    public Id _id { get; set; }
}
public class RootObject{
    public Selector selector { get; set; }
}
serialize tmpObject and PostAsync:
client.PostAsync(url, new StringContent(tmpObject.ToString(), Encoding.UTF8, "application/json"));
