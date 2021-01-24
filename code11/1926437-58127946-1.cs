    class Program
    {
      static void Main(string[] args)
      {
        var FirstObject = new FirstChildClass("FirstObject");
        var SecondObject = new SecondChildClass("SecondObject");
        FirstObject.ReturnMessage();
        SecondObject.ReturnMessage();
        MultipleValueTypes TestDictionary = new MultipleValueTypes();
        TestDictionary.AddObject("FirstObject", FirstObject);
        TestDictionary.AddObject("SecondObject", SecondObject);
        if ( TestDictionary.ADictionary["FirstObject"][0].TypeOfClass()
             == ParentClass.ChildClasses.FirstChildClass )
        {
          TestDictionary.ADictionary["FirstObject"][0]
            = (FirstChildClass)TestDictionary.ADictionary["FirstObject"][0];
        }
        Console.ReadKey();
      }
    }
    public abstract class ParentClass
    {
      public string Name { get; set; }
      public string RandomValue { get; set; }
      public ParentClass(string Name)
      {
        this.Name = Name;
      }
      public virtual void ReturnMessage()
      {
        Console.WriteLine($"This is the {this.GetType().Name} instance");
      }
      public virtual ChildClasses TypeOfClass()
      {
        return ChildClasses.NoChildClass;
      }
      public enum ChildClasses
      {
        NoChildClass = 0,
        FirstChildClass = 1,
        SecondChildClass = 2
      }
    }
    public class FirstChildClass : ParentClass
    {
      public FirstChildClass(string Name)
        : base(Name)
      {
      }
      public override ChildClasses TypeOfClass()
      {
        return ChildClasses.FirstChildClass;
      }
    }
    public class SecondChildClass : ParentClass
    {
      public SecondChildClass(string Name)
        : base(Name)
      {
      }
      public override ChildClasses TypeOfClass()
      {
        return ChildClasses.SecondChildClass;
      }
    }
    class MultipleValueTypes
    {
      public readonly Dictionary<string, List<ParentClass>> ADictionary
        = new Dictionary<string, List<ParentClass>>();
      public void AddObject(string Name, ParentClass variable)
      {
        if ( !ADictionary.ContainsKey(Name) )
        {
          ADictionary.Add(Name, new List<ParentClass>());
        }
        ADictionary[Name].Add(variable);
      }
    }
