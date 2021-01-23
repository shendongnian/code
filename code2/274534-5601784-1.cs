    public abstract class A{
        private string data;
        protected A(string myString){
          data = myString;
        }
    }
    public class B : A {
    
         B(string myString) : base(mystring){}
    }
 
