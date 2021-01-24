    public interface IHaveProperties
    {
        string PropertyX { get; set; }
        string PropertyY { get; set; }
    }
    public class ClassAAA: IHaveProperties
    {
        public string PropertyX { get; set; }
        public string PropertyY { get; set; }
    }
    public class ClassBBB : IHaveProperties
    {
        public string PropertyX { get; set; }
        public string PropertyY { get; set; }
        public string PropertyZ {get;set;}
    }
