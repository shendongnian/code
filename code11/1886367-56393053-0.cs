    private int _movieId;
    
    public int Movie_ID
     {
         set
         {
             if (value == 0)
             {
                 throw new Exception("value cannot be empty");
             }
    
             _movieId = value;
         }
         get
         {
             return _movieId;
         }
     }
