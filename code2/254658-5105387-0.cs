    public interface IClass
    {
     object Data {get; set; }
    }
    
    public class ClassA : IClass
    {
     // implement `Data` property
    }
    
    public class ClassB : IClass
    {
     // implement `Data` property
    }
    
    
    {
     // make the list by adding objects of type `ClassA` or `ClassB`, don't forget to set their `Data` property
     List<IClass> result = new List<IClass>();
     result.Add(new ClassA());
     result.Add(new ClassB());
    }
