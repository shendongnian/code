    public abstract class Element  
    {
        public string Name { get; private set; }
        public abstract IList<string> GetBadParameters();
        public Element( string name) { this.Name = name; }
    }
    public class Wall 
    {
        public Wall( string name): base(name) {}
        public double Length { get; set; }
        public bool IsLoadBearing { get; set; }
        public IList<string> GetBadParameters() {
             List<string> bad = new List<string>();
             if (this.Length <= 0) { bad.Add( this.Name + ": " + nameof( this.Length); }
             if (this.IsLoadBearing && this.Length > whatever) { bad.Add( this.Name + ": " + nameof( this.IsLoadBearing); }
             return bad;
        }
    }
