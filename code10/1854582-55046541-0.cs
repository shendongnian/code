      class Program
      {
        static void Main(string[] args)
        {
          string heading = "yakobusho";
    
          string yourText = "​sho";
          bool back = heading.EndsWith(yourText);
          
          Debug.WriteLine("back = " + back.ToString());
          Debug.WriteLine("yourText length = " + yourText.Length);
    
          string newText = "sho";
          bool backNew = heading.EndsWith(newText);
    
          Debug.WriteLine("backNew = " + backNew.ToString());
          Debug.WriteLine("newText length = " + newText.Length);
    
        }
      }
