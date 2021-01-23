     public class Image 
     { 
        public string Name { get; set;} 
        public IEnumerable<Effect> Effects { get; set; } 
        public IEnumerable<Layer> Layers { get; set; }
        public IEnumerable<Node> Nodes { get { return ((IEnumerable<Node>)Layers).Union((IEnumerable<Node>)Effects); } }
    }
     public class Effect : Node
    {
        public Effect(string name) 
        { 
            this.Name = name; 
        } 
    }
    public class Layer : Node
    { 
          public Layer(string name) { this.Name = name; } 
    }
    public class Node
    {
        public string Name { get; set; }
        public Image Icon { get; set; }
    }
