    public class Branch
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual Company Company { get; set; }
    }
    public class Company
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
 
