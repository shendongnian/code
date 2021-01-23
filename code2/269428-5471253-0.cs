    public class ViewModelX
    {
        public ViewModelX(string name, string description)
        {
            Name = name;
            Description = description;
        }
    
        ...
    
        public override BaseViewModel ToCacheVersion()
        {
            return new ViewModelX(
                Name, // Include the name.
                null  // Ignore the description.
            );
        }
    
        ...
    }
