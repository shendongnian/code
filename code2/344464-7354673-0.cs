    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication33 {
      public class Base {
        [ThreadStatic]
        protected static bool fromDerivedConstructor;
    
        public Base() {}
    
        protected void OnSomeAction(object sender) {
          // if from derived constructor EXIT, else CONTINUE
          if(fromDerivedConstructor) {
            Debug.WriteLine("NO");
            return;
          }
          Debug.WriteLine("YES");
        }
      }
    
      public class Derived : Base {
        public void Raise() {
          base.OnSomeAction(this); // YES if not called by constructor
        }
    
        public Derived() {
          fromDerivedConstructor=true;
          try {
            base.OnSomeAction(this); // NO
            Raise(); // NO
          } finally {
            fromDerivedConstructor=false;
          }
        }
      }
    
      internal class Program {
        private static void Main(string[] args) {
          var c=new Derived(); // NO (twice)
          c.Raise(); // YES
        }
      }
    }
