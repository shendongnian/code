    public class SetOnce<T> 
    {
        private T mySetOnceField;
        private bool isSet;
        
        // used to determine if the value for 
        // this SetOnce object has already been set.
        public bool IsSet
        {
          get { return isSet; }
        }
        // return true if this is the initial set, 
        // return false if this is after the initial set.
        // alternatively, you could make it be a void method
        // which would throw an exception upon any invocation after the first.
        public bool SetValue(T value)
        {
           // or you can make thread-safe with a lock..
           if (IsSet)
           {
              return false; // or throw exception.
           }
           else 
           {
              mySetOnceField = value;
              return isSet = true;
           }
        }
        public T GetValue()
        {
          // returns default value of T if not set. 
          // Or, check if not IsSet, throw exception.
          return mySetOnceField;         
        }
    } // end SetOnce
    public class MyClass 
    {
      private SetOnce<int> myReadonlyField = new SetOnce<int>();
      public void DoSomething(int number)
      {
         // say this is where u want to FIRST set ur 'field'...
         // u could check if it's been set before by it's return value (or catching the exception).
         if (myReadOnlyField.SetValue(number))
         {
             // we just now initialized it for the first time...
             // u could use the value: int myNumber = myReadOnlyField.GetValue();
         }
         else
         {
           // field has already been set before...
         }
         
      } // end DoSomething
     
    } // end MyClass
