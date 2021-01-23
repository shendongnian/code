        public void foo(dynamic f) {
          f.Hello();
        }
        public class Foo {
          public void Hello() { Console.WriteLine("Hello World");}
        }
        [Test]
        public void TestDynamic() {
          dynamic d = new Foo();
          foo(d);
        }
