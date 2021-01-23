    public class parent:child
    {
        private child childObj;
        public parent(string childName)
        {
            childObj = new child(childName);
        }
        
    }
    public class child
    {
        private string name;
    
        public child(string _name)
        {
            name = _name;
        }
    }
