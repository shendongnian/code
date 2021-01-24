	public static void Main()
	{
		new B().test(1);
		new C().test("1");
	}
	
	abstract class A<T> {
	   public void test(T value){
		   Console.WriteLine(value);
	   }
	}
	class B : A<int> {	}
	class C : A<string> { }
