    class ClassName
    {
      public int num;
      public string loc;
    
      public ClassName(int n, string s){
        num = n;
        loc = s;
      }
    }
    
    public void clearArray(){
      for(int x = 0; x < 9; x++)
         for(int y = 0; y < 8; y++)
            myArray[x, y] = new ClassName(-1, "A");
    }
