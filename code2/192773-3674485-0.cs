<pre>
public void Foo(A a){
    Console.WriteLine("Foo(A)" + a.GetType().Name);
    Console.WriteLine("Foo(A)" +a.GetType().BaseType );
}
