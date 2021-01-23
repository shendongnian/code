    public void Main()
    {
        DaClass thing = new DaClass();
    
    	Console.WriteLine(thing[1]);
        Console.WriteLine(thing[Magic.Two]);
        
        
    }
    
    public class DaClass
    {
        private List<string> stuff = new List<string>{"Item1", "Item2", "Item3", "Item4"};
        public string this[Magic m]
        {
            get{return stuff[(int)m];}
            set{stuff[(int)m] = value;}
        }
        
        public string this[int i]
        {
            get{return stuff[i];}
            set{stuff[i] = value;}
        }
    }
    //Results
    //Item2
    //Item3
