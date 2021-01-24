     public class MyClass {
        ...
        int ageValue = 0;
        public int AgeValue {
          get {
            return ageValue
          }
          protected set {
            ... // value validation here
            // your code starts
            if (value != ageValue) { 
              ageValue = value; 
            }
            // your code ends
            else
              return; // do nothing since value == ageValue
            // ageValue has been changed
            // Time (or / and memory) consuming process
            SaveToRDBMS();
            InvalidateCache(); 
          } 
        } 
     ... 
