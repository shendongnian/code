    public class Method
    {
        public List<Parameter> parameters { get; set; }
        public string modifier { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        
        public override bool Equals(object obj)
        {
            return modifier == ((Method)obj)?.modifier && 
                   name == ((Method)obj)?.name && 
                   type == ((Method)obj)?.type && 
                   parameters.SequenceEqual(((Method)obj)?.parameters);
        }
    }
