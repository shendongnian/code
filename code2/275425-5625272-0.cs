    public class MyClass : IComparable<MyClass>
    {
        public string type {get; set;}
        public string title {get; set;}
    
        public int CompareTo(MyClass other) 
        {
            if (other == null) 
            {
               throw new ArgumentNullException("Other");
            }
            else if(this.Type == obj.Type)
            {
                return this.Title.CompareTo(object.Title);
            }
            else if(x.Type == "first")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
    
