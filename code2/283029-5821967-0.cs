    public class User
    {
        public string Name { get; private set; }
    
        public void SetName(string name, INameValidationService service)
        {
            // Insert basic null validation here.
            if (name != this.Name && !service.IsUniqueName(name))
            {
                // Throw some validation exception.
            }
    
            this.Name = name;
        }
    }
