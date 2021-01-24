    using System;
    using System.Runtime.CompilerServices;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var o1 = new O1();
    		o1.DS1();
    		var o2 = new O2();
    		o2.DS1();
    		o2.DS2();
    	}
    	
    	public class Session1
    	{
    		protected readonly Type ownerType;
    		public Session1(Type type)
    		{
    			ownerType = type;
    		}
    		
    		public virtual void DS1([CallerMemberName] string functionName = "")
    		{
    			Console.WriteLine(ownerType.Name + ":" +  GetType().Name + ":" + functionName);
    		}		
    	}
    	
    	public class Session2 : Session1
    	{
    		public Session2(Type type):base(type) { }
    		
    		public virtual void DS2([CallerMemberName] string functionName = "")
    		{
    			Console.WriteLine(ownerType.Name + ":" +  GetType().Name + ":" + functionName);
    		}	
    	}
    	
    	public class O1
    	{
    		private readonly Session1 t;
    		
    		public O1() : this(new Session1(typeof(O1))) { }
    		protected O1(Session1 t)
    		{
    			this.t = t;
    		}
    		public void DS1()
    		{
    			t.DS1();
    		}
    	}
    	
    	public class O2 : O1
    	{
    		private readonly Session2 t;
    		
    		public O2() : this(new Session2(typeof(O2))) { }
    		protected O2(Session2 t) : base(t)
    		{
    			this.t = t;
    		}
    		
    		public void DS2()
    		{
    			t.DS2();
    		}
    	}
    }
