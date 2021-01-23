      //example
    public class SomeCollection{
    public SomeCollection(){}
     private bool[] bools;
      public bool this[int index] {
         get {
            if ( index < 0 || index >= bools.Length ){
               //... Out of range index Exception
            }
            return bools[index];
         }
         set {
            bools[index] = value;
         }
      }
    //...
    }
