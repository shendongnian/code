	public interface Intfc { void xyz();}
	
	public class BaseClass : Intfc
	{
	
		public void xyz()
		{
			Console.WriteLine("In Base Class");
		}
	}
	
	public class Derived : BaseClass,Intfc
	{
		public void xyz()
		{
			Console.WriteLine("In Derived Class");
		}
	}
	
	static void Main()
	{
		Derived mc = new Derived();
		mc.xyz(); //In Derived Class
		((BaseClass)mc).xyz(); //In Base Class
		((Intfc)mc).xyz(); //In Derived Class
	
		
	
	}
