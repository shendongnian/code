    public class MyProvider {
         object numberLock = new object();
         ...
         public void SetNumber(int num) {
              lock(numberLock) {
                   // Do Stuff
              }
         }
    }
