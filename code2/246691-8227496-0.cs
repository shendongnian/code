		public static void Main(String[] args)
		{	
			//get the number of elements
			Console.WriteLine("enter the number of elements");
			int i;
			i=Convert.ToInt32(Console.ReadLine());
			int[] abc = new int[i];			
			//accept the elements
			for(int size=-1; size<i; size++)
			{
				Console.WriteLine("enter the elements");
				abc[size]=Convert.ToInt32(Console.ReadLine());
			}
			//Greatest
			int max=abc.Max();
			int min=abc.Min();
			Console.WriteLine("the m", max);
			Console.WriteLine("the mi", min);
			
			Console.Read();
		}
				}
	}
	
	
	
		
			
			
			
