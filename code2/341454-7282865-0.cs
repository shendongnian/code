    class Program
    {
        static void Main(string[] args)
        {
            var obj = new ParentClass();
            Console.WriteLine("Parent says: " + obj.ShowYourHand());
    
            var obj2 = new ChildClass();
            Console.WriteLine("Child says: " + obj2.ShowYourHand());
    
            Console.ReadLine();
        }
    }
    
    public class ParentClass
    {
        public string ShowYourHand()
        {
            var obj = this.GetExternalObject();
            return obj.ToString();
        }
        protected virtual IExternalObject GetExternalObject()
        {
            return new ExternalObject();
        }
    }
    
    public class ChildClass : ParentClass
    {
        protected override IExternalObject GetExternalObject()
        {
            return new ExternalObjectStub();
        }
    }
    
    public interface IExternalObject { }
    
    public class ExternalObject : IExternalObject
    {
        public override string ToString()
        {
            return "ExternalObject";
        }
    }
    
    public class ExternalObjectStub : IExternalObject
    {
        public override string ToString()
        {
            return "ExternalObjectStub";
        }
    }
