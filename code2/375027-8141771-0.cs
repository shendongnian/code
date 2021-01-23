    public interface IVisible
    {
        string VisibleProperty { get; set; }
    }
    
    internal class InvisibleClass : IVisible
    {
        public string VisibleProperty { get; set; }
    }
