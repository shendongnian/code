      static void Main(string[] args)
        {
            string root = @"D:\";
            List<string> list= Recursive(root);
    
            foreach (string l in list)
            {
                Console.WriteLine(l);
            }
    
        }
         
          static IEnumerable<string> Recursive(string root )
        {
             
              string[] subdirectories = Directory.GetDirectories(root);
              yield return root;
              if(subdirectories !=null && subdirectories.Length>0)
              {
                  foreach(var sub in subdirectories)
                  {
                     foreach(var subsub in  Recursive(sub))
                     yield return subsub;
                  }   
              }
              else
              {
                 yield break;
              }
        }
