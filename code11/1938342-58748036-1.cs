    public class UpdateRequest : PatchRequest
    {
        [MaxLength(80)]
        [NotNullOrWhiteSpaceIfSet]
        public string Name
        {
           get => _name;
           set { _name = value; SetHasProperty(nameof(Name)); }
        }  
    }
    public abstract class PatchRequest
    {
        private readonly HashSet<string> _properties = new HashSet<string>();
    
        public bool HasProperty(string propertyName) => _properties.Contains(propertyName);
    
        protected void SetHasProperty(string propertyName) => _properties.Add(propertyName);
    }
