       class RectangleWithoutFields {
  
      // just autoproperties , no fields
         public int X {get;set;}
         public int Y { get; set;}
 
        public RectangleWithoutFields ()
       {
        X=0;
        Y=0; 
        }
       public void ChangeProperties(int x, int y)
       {
            X=x;
            Y=y;
       }
     }
 
