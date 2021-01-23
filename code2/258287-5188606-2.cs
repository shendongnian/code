    public class InstanceClass
    {
       private string StaticProperty
       {
             get { return StaticClass.StaticProperty; }
       }
       private StaticMethod()
       {
            StaticClass.StaticMethod();
       }
       public InstanceClass()
       { }
    }
