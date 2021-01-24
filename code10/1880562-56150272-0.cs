   public abstract class A<T, TB, C, D>
      where T : class
      where C : FooParameter
      where D : FooResponse
      where TB : B<C,D>    {
      public TB B { get; set; }
      public A()
      {
         //instantiate B property
      }
   }
You need to be able to define all of the types that a generic needs at compile time, which you can as above.
