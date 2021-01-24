abstract class A {
   public double Foo {get; protected set;}
}
class B : A {
   public B(){
      Foo = 1;
   }
}
class C : A {
   public C(){
      Foo = 2;
   }
}
class Test {
   A test = new B();
   var foo = test.Foo;
}
