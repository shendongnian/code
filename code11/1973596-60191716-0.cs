	using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		class ABC
		{
			public List<A> LA { get; set; }
		}
		
		class A
		{
			public List<B> LB { get; set; }
		}
		class B
		{
			public List<C> LC { get; set; }
		}
		class C
		{
			public int x { get; set; }
			public int y { get; set; }
			public int z { get; set; }
		}
		
		
		public static void Main()
		{
			
			var abc = new ABC 
			{ 
				LA = new List<A> 
				{ 
					new A 
					{ 
						LB = new List<B> 
						{ 
							new B 
							{ 
								LC = new List<C> 
								{ 
									new C { x =1, y= 2, z= 3}, 
									new C { x =1, y= 2, z= 3} 
								} 
							},
							new B 
							{ 
								LC = new List<C> 
								{ 
									new C { x =1, y= 2, z= 3}, 
									new C { x =1, y= 2, z= 3} 
								} 
							} 
						} 
					},
					new A 
					{ 
						LB = new List<B> 
						{ 
							new B 
							{ 
								LC = new List<C> 
								{ 
									new C { x =1, y= 2, z= 3}, 
									new C { x =1, y= 2, z= 3} 
								} 
							},
							new B 
							{ 
								LC = new List<C> 
								{ 
									new C { x =1, y= 2, z= 3}, 
									new C { x =1, y= 2, z= 3} 
								} 
							} 
						} 
					} 
					
				} 
			};
			
			Console.WriteLine(abc.LA.Sum(xabc => xabc.LB.Sum(xb => xb.LC.Count)));
			
		}
	}
