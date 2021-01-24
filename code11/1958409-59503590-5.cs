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
                   ( parameters == null && ((Method)obj)?.parameters == null || 
                     parameters != null && ((Method)obj)?.parameters != null && parameters.SequenceEqual(((Method)obj).parameters));
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = parameters != null ? parameters.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (modifier != null ? modifier.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
