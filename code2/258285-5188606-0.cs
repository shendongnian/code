    public  class StaticClass {}
    public class InstanceClass
    {
       static StaticClass StaticProperty {get;set;}
       public InstanceClass()
       {
          InstanceClass.StaticProperty = new StaticClass();
       }
    }
