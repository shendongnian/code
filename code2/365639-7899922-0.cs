    public class A{
       public void CallB(){
          ClassB.MyMethod(this);
       }
    }
    
    public static class B {
       public static void MyMethod(A a){
           // get info about class a here.
       }
    }
