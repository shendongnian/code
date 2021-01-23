    public interface IChangeable
    {
        bool Changed { get; set; }
    }
    
    public class Changeable<T> : IChangeable 
    {
        public bool Changed { get; set; }
        public T Value { get; set; }
    }
    public class MyModel
    {
        [Range(1, 10), Display(Name = "Some Integer")]
        public Changeable<int> SomeInt { get; set; }
        [StringLength(32, MinimumLength = 6), Display(Name = "This String")]
        public Changeable<string> TheString { get; set; }
    } 
