    void Main()
    {
        Console.WriteLine("first piece of code:");
        Context c = new Context();
        c.newArray2[c.IndTemp] = c.newArray1[c.IndTemp++];
    
        Console.WriteLine();
        
        Console.WriteLine("second piece of code:");
        c = new Context();
        c.newArray2[c.IndTemp++] = c.newArray1[c.IndTemp];
    }
    
    class Context
    {
        private Collection _newArray1 = new Collection("newArray1");
        private Collection _newArray2 = new Collection("newArray2");
        private int _IndTemp;
        
        public Collection newArray1
        {
            get
            {
                Console.WriteLine("  reading newArray1");
                return _newArray1;
            }
        }
    
        public Collection newArray2
        {
            get
            {
                Console.WriteLine("  reading newArray2");
                return _newArray2;
            }
        }
        
        public int IndTemp
        {
            get
            {
                Console.WriteLine("  reading IndTemp (=" + _IndTemp + ")");
                return _IndTemp;
            }
            
            set
            {
                Console.WriteLine("  setting IndTemp to " + value);
                _IndTemp = value;
            }
        }
    }
    
    class Collection
    {
        private string _name;
        
        public Collection(string name)
        {
            _name = name;
        }
        
        public int this[int index]
        {
            get
            {
                Console.WriteLine("  reading " + _name + "[" + index + "]");
                return 0;
            }
            
            set
            {
                Console.WriteLine("  writing " + _name + "[" + index + "]");
            }
        }
    }
