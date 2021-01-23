    class FooPropertyDeclaringType
    {
        public static readonly DependencyProperty FooProperty = 
            DependencyProperty.Register("Foo", typeof(int), typeof(FooPropertyDeclaringType));
    }
    class SomeUnrelatedType : DependencyObject { }
    class Program
    {
        static void Main()
        {
            var obj = new SomeUnrelatedType();
            obj.SetValue(FooPropertyDeclaringType.FooProperty, 10);
            Debug.Assert(10 == (int)obj.GetValue(FooPropertyDeclaringType.FooProperty));
        }
    }
