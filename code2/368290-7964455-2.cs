      public float GetMaxX()
      {
          if(RawData == null)
          {
             throw new NullReferenceException();
          }
          //DO other stuff to find max X
          return MAX_X; //as float
       }
