    //#define __virtual
    #define __direct
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    
    
    namespace VirtualEvents
    {
    
    	
    
    	#if __virtual
    	#region
    	public class A<T> 
    	{ 
    		public virtual event EventHandler e;
    
    		public virtual void Fire() { e(this, null); }
    	}
    
    	public class Aadapter<T1, T2> : A<T1> 
    	{ 
    		A<T2> a;
    
    
    		public override event EventHandler e
    		{
    			add { a.e += new EventHandler(value); }
    			remove { a.e -= new EventHandler(value); }
    		}
    
    		public override void Fire()
    		{
    			a.Fire();
    		}
    
    		public Aadapter(A<T2> _a) 
    		{ 
    			a = _a; 
    		} 
    	}
    	#endregion
    	#elif __direct
    	#region
    	
    	public delegate EventHandler EventHandlerPtr();
    		public class eventPtr
    		{
    			public EventHandler _event;
    		}
    	public class A<T>
    	{
    
    		
    		//internal EventHandler _event;
    		public eventPtr _event = new eventPtr();
    
    		public event EventHandler e
    		{
    			add { _event._event += value; }
    			remove { _event._event -= value; }
    		}
    
    		public void Fire() { _event._event(this, null); }
    
    
    	}
    
    	public class Aadapter<T1, T2> : A<T1>
    	{
    		A<T2> a;
    
    		public Aadapter(A<T2> _a)
    		{
    			a = _a;
    			this._event = a._event;
    		}
    	}
    
    	#endregion
    	#else
    	#region 
    	public class A<T>
    	{
    		public event EventHandler e;
    
    		public void Fire() { e(this, null); }
    	}
    
    	public class Aadapter<T1, T2> : A<T1>
    	{
    		A<T2> a;
    
    		public Aadapter(A<T2> _a)
    		{
    			a = _a;
    
    			a.e += new EventHandler(a_e);
    			e += new EventHandler(Aadapter_e);
    		}
    
    		void Aadapter_e(object sender, EventArgs e)
    		{
    			a.e -= new EventHandler(a_e);
    			a.Fire();
    			a.e += new EventHandler(a_e);
    		}
    
    		void a_e(object sender, EventArgs e)
    		{		
    			this.e -= new EventHandler(Aadapter_e);
    			Fire();	
    			this.e += new EventHandler(Aadapter_e);
    		}
    	}
    	#endregion
    	#endif
    
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			var a = new A<double>();
    			var q = new Aadapter<int, double>(a);
    
    			a.e += new EventHandler(a_e);
    			q.e += new EventHandler(q_e);
    
    			
    			a.Fire();
    			q.Fire();
    			((A<int>)q).Fire();
    
    			Console.ReadKey();
    		}
    
    		static void a_e(object sender, EventArgs e)
    		{
    			Console.WriteLine("From a");
    		}
    
    		static void q_e(object sender, EventArgs e)
    		{
    			Console.WriteLine("From q");
    		}
    
    	}
    }
