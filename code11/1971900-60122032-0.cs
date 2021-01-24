class Program
{
    private static Obj A = new Obj( ... );
    private static IReadOnlyList<Int32> capturedValues;
    class Obj2 : Obj
    {
        public override Object[] MethodX( Int32 a, Int32, b, Int32 c )
        {
            Program.capturedValues = new Int32[] { a, b, c };
        }
    }
    static void Main()
    {
        Obj oldA = Program.A;
        Program.A = new Obj2();
        
        Function( () => A.MethodX( 10, 20, 30 ) );
        Console.WriteLine( "captured: " + String.Join( ", ", capturedValues.Select( i => i.ToString() ) ) );
        // Restore old A:
        Program.A = oldA;
    }
}
However if you can't directly intercept the `MethodX` call (or otherwise inject your own code somewhere into `Obj`'s control-flow) then no, you cannot (at least, not without subverting the CLR).
The argument values `10, 20, 30` are embedded as constant locals inside the anonymous lambda inside `main` where they are inaccessible.
So this...:
static void Main() {
    Function( () => A.MethodX( 10, 20, 30 ) );
}
static void Function( Func<object[]> m )
{
      object[] result = m();
      ...
}
...is equivalent to this:
static void Main() {
    
    Func<Object[]> func = new Func<Object[]>( Program.Foo );
    Function( func );
}
static void Function( Func<object[]> m )
{
      object[] result = m();
      ...
}
static Object[] Foo() {
    Program.MethodX( 10, 20, 30 );
}
...where the same values are demonstrably inaccessible to `Main`.
