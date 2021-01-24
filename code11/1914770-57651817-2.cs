    public class HL7Message
    {
       public List<Segment> Segments { get; set; }
    }
    
    public class Segment
    {
       public string Name { get; set; }
       public List<Field> Fields { get; set; }
    }
    
    public class Field
    {
       public string Name { get; set; }
       public List<Field> Fields { get; set; }
    }
