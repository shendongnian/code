    public class Program
    {
        public static void Main()
        {
		     int n = 10;
             string Name = n.ChildConver();
		     System.Console.WriteLine(Name);
	    }
    }
    public static class Ext
    {
	    public static string ChildConver(this int Name)
        {
            string Namecovert = Name.ToString() + " Convertion";
            return Namecovert;
        }
    }
