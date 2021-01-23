    public interface IMyInterface2<T> where T : IMyInterface1
    {
        string prop1 { get; set; }
        IList<T> prop2 { get; set; }
    }
