    [Serializable]
    public class MyClass
    {
       public string mystr = "NotWorking!";
       public MyClass(string _mystr)
       {
          mystr = _mystr;
       }
       public override string ToString()
       {
          return mystr;
       }
    }
