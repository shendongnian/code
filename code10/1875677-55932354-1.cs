    public interface IFoo<TBar> where TBar: IBar
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<TBar> TBars{ get; set; } //association with another entity
    }
    
    public class Foo : IFoo<Bar>
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bar> Bars{ get; set; }
    
    }
