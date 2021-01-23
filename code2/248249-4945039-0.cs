    public abstract class Collaborator {
        public virtual Decimal Salary(object value);
    }
    
    public class Sales : Collaborator {
        public override Decimal Salary(object value) {}
        public List<Collaborator> Subordinates { get; set; }
        public Collaborator Chief { get; set }
    }
    
    public class Manager : Collaborator {
        public override Decimal Salary(object value) {}
        public List<Collaborator> Subordinates { get; set; }
        public Collaborator Chief { get; set }
    }
    
    public class Employee : Collaborator {
        public override Decimal Salary(object value) {}
        public Collaborator Chief { get; set }
    }
