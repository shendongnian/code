    public interface ISettable
    {
        string ID { get; set; }
        string Val { get; set; }
    }
    public void LoadData<T>(string id, string value) where T : ISettable, new()
    {
        this.Item.Add(new T { ID = id, Val = value });
    }
