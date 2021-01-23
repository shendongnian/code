    public class Relationship
    {
        public Company { get; set; }
        public virtual void Foo()
        {
            ....
        }
    }
    
    public class Debtor : Relationship
    {
        public override void Foo()
        {
            ....
        }
    }
    public class Creditor : Relationship
    {
        public override void Foo()
        {
            ....
        }
    }
    public class Lead : Relationship
    {
        public override void Foo()
        {
            ....
        }
    }
