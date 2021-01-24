    [Serializable]
    public class User1 
    {
        public string BB;
        // The default constructor is required for serialization
        public User1()
        {
            // assign default values
            BB = "hello world";
        } 
        public User1(string bb)
        {
            // assign passed values
            BB = bb;
        }
    }
    
