    public class A
    {
       public string MyString;
    }
    
    public class AMeta
    {
       [TheAttribute("etc")]
       public object MyString;
    }
    
    ...
    
    var myA = new A();
    var metaType = Type.GetType(myA.GetType().Name + "Meta");
    var attributesOfMyString = metaType.GetMember("MyString").GetCustomAttributes();
