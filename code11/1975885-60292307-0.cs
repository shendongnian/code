    public class Globals
    {
    private static string _myData;
    public static string MyData
    {
        get
        {
            // Reads are usually simple
            return _myData;
        }
        set
        {
            _myData = value;
        }
     }
    
    }
