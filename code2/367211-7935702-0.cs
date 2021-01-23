    public class AClass
    {
        public int Id { get; set; }
        public ICollection<BClass> BClasses { get; set; }
    }
    public class BClass
    {
        public int Id { get; set; }
        public ICollection<AClass> AClasses { get; set; }
    }
