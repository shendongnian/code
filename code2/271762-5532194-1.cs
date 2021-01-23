    using System;
    using System.Linq;
    
    namespace X
    {
        public class MyType
        {
    		public delegate void DoInitialize(MyType instance);
    		public int a,b,c;
    
    		public MyType(DoInitialize initialize) 
    		{
    			initialize(this);
    		}
    
    		public MyType(params Action<MyType>[] initializers) 
    		{
    			foreach (var initializer in initializers)
    				initializer(this);
    		}
    
    		public static void LambdaApproach()
    		{
    			var instance = new MyType(
    					i => i.a = 1,
    					i => i.b = 2,
    					i => i.c = 42);
    			Console.WriteLine("{0}, {1}, {2}", instance.a, instance.b, instance.c);
    		}
    
    		public static void MulticastApproach()
    		{
    			var lambdas = new DoInitialize[] {
    					i => i.a = 1,
    					i => i.b = 2,
    					i => i.c = 42, };
    
    			var instance = new MyType((DoInitialize) Delegate.Combine(lambdas.ToArray()));
    			Console.WriteLine("{0}, {1}, {2}", instance.a, instance.b, instance.c);
    		}
    
    		public static void Main(string[] args)
    		{
    			LambdaApproach();
    			MulticastApproach();
    		}
        }
    
    }
