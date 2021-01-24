    public class Allposition
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class Allrotation
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double w { get; set; }
    }
    public class Allscale
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class Linepos0
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
    public class Linepos1
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
    public class SaveValue
    {
        public int Id { get; set; }
        public Allposition Allposition { get; set; }
        public Allrotation Allrotation { get; set; }
        public Allscale Allscale { get; set; }
        public Linepos0 Linepos0 { get; set; }
        public Linepos1 Linepos1 { get; set; }
        public int Movetype { get; set; }
    }
    public class Response
    {
        public List<SaveValue> SaveValues { get; set; }
        // NoteValues can safely be removed from model if you don't need the values
        public List<NoteValue> NoteValues { get; set; }
    }
    // optional
    public class NoteValue
    {
        public int Movenumber { get; set; }
        public string Notemsg { get; set; }
    }
