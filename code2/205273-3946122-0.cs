    class Program
    {
       static void Main(string[] args)
       {
          TimeSpan ts1 = TimeIt(OpenExistingFileWithCheck);
    
          TimeSpan ts2 = TimeIt(OpenExistingFileWithoutCheck);
    
          TimeSpan ts3 = TimeIt(OpenNonExistingFileWithCheck);
    
          TimeSpan ts4 = TimeIt(OpenNonExistingFileWithoutCheck);
       }
    
       private static TimeSpan TimeIt(Action action)
       {
          int loopSize = 10000;
    
          DateTime startTime = DateTime.Now;
          for (int i = 0; i < loopSize; i++)
          {
             action();
          }
    
          return DateTime.Now.Subtract(startTime);
       }
    
       private static void OpenExistingFileWithCheck()
       {
          string file = @"C:\temp\existingfile.txt";
          if (File.Exists(file))
          {
             using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read))
             {
             }
          }
       }
    
       private static void OpenExistingFileWithoutCheck()
       {
          string file = @"C:\temp\existingfile.txt";
          using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read))
          {
          }
       }
    
       private static void OpenNonExistingFileWithCheck()
       {
          string file = @"C:\temp\nonexistantfile.txt";
          if (File.Exists(file))
          {
             using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read))
             {
             }
          }
       }
    
       private static void OpenNonExistingFileWithoutCheck()
       {
          try
          {
             string file = @"C:\temp\nonexistantfile.txt";
             using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read))
             {
             }
          }
          catch (Exception ex)
          {
          }
       }
    }
