    namespace Foo {
      public class Bar {
        public void Method() {
          // Do Other Stuff
        }
        public void OtherMethod() {
          // Do Some Stuff
          this.Method(); // Do Other Stuff
          // Instead of Foo.Bar.Method()
        }
      }
    }
