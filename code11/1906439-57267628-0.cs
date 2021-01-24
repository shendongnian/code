// this method have a optional parameter
public static void Foo(int a = 3) { }
delegate void SampleDelegate(int a = 3);
static void Main(string[] args)
{
    SampleDelegate del = Foo;
	// pass Type.Missing
	del.DynamicInvoke(Type.Missing);
}
