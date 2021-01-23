    public abstract class Field
    {
       public abstract void Process();
    }
    
    public class ExtendedField : Field
    {
       public override void Process() { /*Extended Field Specific Stuff Here*/ }
    }
    
    //consumer code
    
    public void DoStuffWithABunchOfFieldsOfUnknownType(IEnumerable<Field> fields)
    {
       foreach (Field field in fields) { field.Process(); }
    }
