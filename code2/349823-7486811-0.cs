    public class SomeClass {
       public int test = 1;
       static void Main(string[] args) {   
           SomeClass myClass = new SomeClass(); // Will instantiate test as 1
           myClass.resetTest();
    
           Console.Write(myClass.test); // Should be 0
       }
    
       public void resetTest() {
           test = 0;
       }
    }
