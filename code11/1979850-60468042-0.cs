public class YourClass
{
   readonly string readonlyField;
   public int ImmutableIntProperty {get;}
   public YourClass(string field, int value)
   {
       readonlyField = field;
       ImmutableIntProperty = value;
   }
}
