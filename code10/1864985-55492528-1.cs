    static void Main(string[] args)
    {
        var List1 = new File.ReadAllLines("path of text file.txt");
        
            string input;
            List<string> High256 = new List<string>();
            foreach(var item in List1)
            {
                if(int.TryParse(item, out var tempInt))
                  {
                      High256.Add(tempInt);
                      Console.WriteLine(High256);
                  }
               
            }
           
        
    }
