    [Serializable]
    public class User1 
    {
        // either initialize fields with a default value here
        public string BB = "";
        
        // Use the default constructor (= without parameters)
        // if you implement other constructors the default constructor
        // is always mandatory for serialization!
        public User1()
        {
            BB = "hello world";
        }
        // use a specific constructor
        public User1(string bb)
        {
            BB = bb;
        }
    }
