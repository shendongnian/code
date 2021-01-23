    public class MyClass : IComparable<MyClass>
    {
        public string Type {get; set;}
        public string Title {get; set;}
   
        public int CompareTo(MyClass other) 
        {
            if (other == null) 
            {
               throw new ArgumentNullException("other");
            }
            else if(this.Type == other.Type)
            {
                return this.Title.CompareTo(other.Title);
            }
            else if(this.Type == "first")
            {
                return 1;
            }
            else
            {
                return -1;
            }
            // ...Or whatever you feel your sort needs to take into account.
        }
    }
    
