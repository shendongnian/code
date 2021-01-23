    class A : DependancyObject {
      static DependancyProperty PropertyFoo = DependanceProperty.Register( "Foo", typeof(int), typeof(A), new PropertyMetadata( 5 ) );
    
      int Foo {
        get { return (int)GetValue( PropertyFoo ); }
        set { SetValue( PropertyFoo, value ); }
      }
