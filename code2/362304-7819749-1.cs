	public class A<T>
	{
		public B<T> b;
		public void MethodA()
		{
			b = new B<T>(this);
		}
	}
  
	public class B<T> 
	{   
		public A<T> a;
		public B(A<T> myObjA)    
		{    
			a = myObjA;   
		}
	}    
