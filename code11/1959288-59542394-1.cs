    public class BaseTable
    {
        public Guid Id { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
    
    public class MyTableA: BaseTable
    {
        // Navigation properties
        public virtual TypeA A { get; set; }
    }
