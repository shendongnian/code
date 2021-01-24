    public interface IBase
    {
        int Id { get; }
    }
    public class Customer : IBase
    {
        public string Name { get; set; }
        public int Id { get ; set ; }
    }
    public T Get<T>(int id) where T : IBase
    {
        string json = DoSomething(); // <-- making it easy for this post
        List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
        return items.FirstOrDefault(i => i.Id = id);
    }
