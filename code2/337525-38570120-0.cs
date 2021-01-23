    public class SomeCustomException : Exception
    {
        public string PropertyName { get; }
        public SomeCustomException(string propertyName) 
            : base($"Property {propertyName} was null)
        {
            this.PropertyName = propertyName;
        }
    }
    public class Animal
    {
        public string Name
        {
            get { Throw(); }
        }
        private static void Throw([CallerMemberName] string propertyName = null)
        {
            // propertyName will be 'Name'
            throw new CustomException(propertyName);
        }
    }
