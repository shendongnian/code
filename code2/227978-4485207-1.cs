    public struct MyBool
    {
       internal enum Values {True=1, False, FileNotFound};
       Values value;
       public MyBool(Values v) 
       {
          value = v; 
       }
    }
    MyBool b = new MyBool(MyBool.Values.FileNotFound);
