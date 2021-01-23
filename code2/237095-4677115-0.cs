    //#define __virtual
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    
    namespace VirtualEvents
    {
    
    	
    
    	#if __virtual
    
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
    
    	#else
    
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
