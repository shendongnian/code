    [Serializable()]
    class CellMatrix {
     Cell [] mCells;
     public int Rows { get; }
     public int Columns { get; }
     public Cell this (int i, int j) {
      get {
       return mCells[i + Rows * j];    
      }   
      // setter...
     }
     // constructor taking rows/cols...
    }
