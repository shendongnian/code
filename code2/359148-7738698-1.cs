    void Main()
    {
    		Guid id = Guid.NewGuid();
    		string personName = "MyName";
    		MyClass object1 = new MyClass(id, personName);
    		MyClass object2 = new MyClass(id, personName);
    		//This returns false, but I'd like it to return true:
    		Console.WriteLine(object1.Equals(object2));
    		//[edit]...by using, for example:
    		Console.WriteLine(MyClassEqualityComparer.Instance.Equals(object1, object2));
    }
    
    public class MyClass
    {
    	private Guid _id;
    	private string _personName;
    	public MyClass(Guid id, string personName)
    	{
    		_id = id;
    		_personName = personName;
    	}
    }
    
    public class MyClassEqualityComparer:IEqualityComparer<MyClass>
    {
      private static FieldInfo personNameField=typeof(MyClass).GetField("_personName",BindingFlags.Instance|BindingFlags.NonPublic);
      private static FieldInfo idField=typeof(MyClass).GetField("_id",BindingFlags.Instance|BindingFlags.NonPublic);
    
      public bool Equals(MyClass o1,MyClass o2)
      {
    	if(o1==o2)
    	  return true;
    	if(o1==null||o2==null)
    	  return false;
    	string name1=(string)personNameField.GetValue(o1);
    	string name2=(string)personNameField.GetValue(o2);
    	if(name1!=name2)
    	  return false;
    	Guid id1=(Guid)idField.GetValue(o1);
    	Guid id2=(Guid)idField.GetValue(o2);
    	return id1==id2;
      }
    
      public int GetHashCode(MyClass o)
      {
        if(o==null)
          return 0;
    	string name=(string)personNameField.GetValue(o);
    	Guid id=(Guid)idField.GetValue(o);
    	return name.GetHashCode()^id.GetHashCode();
      }
      private MyClassEqualityComparer()
      {
      }
      
      public static readonly IEqualityComparer<MyClass> Instance=new MyClassEqualityComparer();
    }
