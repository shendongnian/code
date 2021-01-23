     public static class Class1
                    {
    
               public static void startgenerationofnames()
              {
                   string[] lines = System.IO.File.ReadAllLines("names.txt");
                   foreach (string value in lines)
                  {
                    Debug.WriteLine(lines);
                    //call next class with the current value
                  }
            }
        }
