    public class Base
	{		
		public Base(int a)
		{
            // this method body is executed first
		}
	}
	
	public class DerivedA : Base
	{
		public DerivedA(string name, int val) : base(val)
		{
            // this method body is executed second (last if you used this constructor, e.g. new DerivedA("hello", 1) )
		}
		
		public DerivedA() : this("test", 5) // this will call the constructor above, which will first call base. So the final chain is: base, constructor above, this constructor
		{
		    // this method body is executed third (last if you used this constructor, e.g. new DerivedA() )
		}
	}
	
	public class DerivedB : Base
	{
		public DerivedB(string name, int val) : base(val)
		{
		}
		
		public DerivedB() : base(5) // this will call the base constructor, and then this constructor. The constructor above will not be used.
		{
		
		}
	}
