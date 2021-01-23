    public class Block
    {
         public List<Child> Children { get; set; }
         public string Name { get; set; }
    }
    public class Child
    {
         public List<Field> Fields { get; set; }
    }
    public class Field
    {
         public List<string> FieldNames { get; set; }
    }
