    abstract class Base {
         protected List<string> TheList
         {
             get {
                 Debug.Assert(MyList.Count != 0);
                 return MyList;
             }
             set {
                 Debug.Assert(value.Count != 0);
                 MyList = value;
             }
         }
         private List<string> MyList = new List<string>();
    }
