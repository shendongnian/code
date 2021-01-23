    public class MyObject
    {
        public string[] Columns { get; private set;}
      
        public MyObject(int numColumns)
        {
            Columns = new string[numColumns];
        }   
    }
