    public class Materials
    {
    public DateTime timestamp { get; set; }
    public string _event { get; set; }
    public Raw[] Raw { get; set; }
    }
    public class Raw
    {
    public string Name { get; set; }
    public int Count { get; set; }
    }
