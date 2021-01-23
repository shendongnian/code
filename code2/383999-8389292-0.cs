    namespace Blah
    {
    public class TernaryTest
    {
    public static void Main(string[] args)
    {
    bool someBool = true;
    string someString = string.Empty;
    string someValue = "hi";
    object result = null;
     
    // if someBool is true, assign someValue to someString,
    // otherwise, effectively do nothing.
    result = (someBool) ? someString = someValue : null;
    } // end method Main
    } // end class TernaryTest
    } // end namespace Blah 
