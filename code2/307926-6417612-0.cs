    void Main()
    {
    	var derived = new Derived();
    	derived.Field = 10;
    	var fieldInfo = typeof(Base).GetFields(
                            BindingFlags.NonPublic | BindingFlags.Instance)[0];
    	fieldInfo.SetValue(derived, 20);
    	Console.WriteLine(derived.Field);
    	Console.WriteLine(fieldInfo.GetValue(derived));
    }
    
    public class Base {
      public virtual int Field { get; set; }
    }
    
    public class Derived : Base {
      int _field;
      public override int Field 
      { 
          get { return _field; } 
          set { Console.WriteLine("Setter called."); _field = value; } 
      }
    }
