    internal interface IHeader
    {
        string title { get; set; }
    }
    class Head1 : IHeader
    {
        string IHeader.title { get; set; }
    }
