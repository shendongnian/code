    public class Class1
    {
        static string[] lines = System.IO.File.ReadAllLines("names.txt");
        public static string startgenerationofnames()
        {
            foreach (string value in lines)
            {
                 Debug.WriteLine(line); // not lines
                 //call next class with the current value
            }
         }
    }
