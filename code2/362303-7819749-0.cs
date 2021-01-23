	public class A<T>
	{
		public B b;
		public void MethodA()
		{
			b = new B(this);
		}
	}
  
	public class B    
	{   
		public A<TypeC> a;
		public B(A<TypeC> myObjA)    
		{    
			a = myObjA;   
		}
	} 
