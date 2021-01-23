    class MyObjectProvider
    {
       public static MyObject CreateByPath(string path) 
       { 
          return new MyObject
                  {
                      Path = path;
                  };
                   
       }
       
       public static MyObject CreateByContent(string content) 
       { 
          return new MyObject
                  {
                      Content = content;
                  };
       }
    }
