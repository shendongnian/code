    public class MyClass{
      private static int instanceCounter = 0;
    
      private int instanceNumber;
      public MyClass(){
        lock(instanceCounter)
        {
            instanceNumber = instanceCounter++;
        }
      }
      ...
    }
