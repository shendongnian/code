    class MyObject {
      public static MyObject FromContent(string content) {
        return new MyObject(content);
      }
    
      public static MyObject FromFile(string path) {
        return new MyObject(ReadContentFromFile(path));
      }
    }
