    public class SomeModel
    {
       public MyEnum EnumValue { get; set; }
       public int BindToThisGuy
       {
          get { return (int) EnumValue; }
          set { EnumValue = (MyEnum)value; }
       }
    }
