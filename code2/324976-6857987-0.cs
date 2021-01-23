    public class ScrabbleViewModel
    {
      readonly bool[,] matrix = new bool[15,15];
    
      public bool[,] GameMatrix
      {
          get { return matrix; }
      }
    }
