        string s;
        object o = null;
        s = o.ToString();
        //returns a null reference exception for s.
        
        string s;
        object o = null;
        s = Convert.ToString(o);
        //returns an empty string for s and does not throw an exception.
    
     static void Main(string[] args)
            {
                try
                {
                    string s;
                    object o = null;
                    s = (string)o;
                    Console.WriteLine(s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
               
                
                Console.ReadKey();  
            }
     //returns an empty string for s and does not throw an exception.
