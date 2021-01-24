    class Program
      {
        static void Main(string[] args)
        {
          string newProjectNumber = "000006"; // new project number you want to add
          DirectoryInfo d = new DirectoryInfo(@"C:\Test");//Assuming Test is your Folder
          DirectoryInfo[] dirs = d.GetDirectories(); // get the full list of dirs inside C:\Test
    
          foreach (DirectoryInfo dir in dirs) // iterating over dirs
          {
            string dirName = dir.Name;
            if (dirName.Substring(0,6) == newProjectNumber)
            {
              Console.WriteLine("This folder already exists.");
            }
          }
          Console.ReadLine();
        }
      }
