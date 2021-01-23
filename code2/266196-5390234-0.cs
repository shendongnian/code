    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	string[] lines = File.ReadAllLines("Yourfile.txt");
            int  maxLength = 0;
    	foreach (string line in lines)
    	{
    	    if(line.Length > maxLength)
                      maxLength = line.Length
    	}
    
           // After this, again iterate through lines array. For every String element in it, if the length of the string is less than the maxLength, then append last character (maxLength - line.Length) times. To get the last character you can use 
    char last = line[line.Length - 1];
        }
    }
