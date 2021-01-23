      public static class Extensions
        {
            static object myporpertyvalue = null;
            public static void SetMyProperty(this Rectangle rect, object value) 
            {
                myporpertyvalue = value;
            }
    
            public static object GetMyProperty(this Rectangle rect) 
            {
               return myporpertyvalue ;
            }
        }
