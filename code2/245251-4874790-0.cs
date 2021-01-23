      using System;
        
        namespace xyzApp
        {
        	class Program
        	{
        		public static void Main(string[] args)
        		{    			
        			Test1Class t = new Test1Class ();
        			t.Add(4);
        			t.Add(11.1);
        			t.showValue();
        			Console.Write("Press any key to continue . . . ");
        			Console.ReadKey(true);
        		}
        	}
        	
        	
        	class TestClass{
        		protected  int sum =0;
        		
        		public void Add(int x)
        		{
        			sum+=x;
        		}
        		
        		public void showValue()
        		{
        			Console.WriteLine(" the sum is : {0}",sum);
        		}
        	}
        	
        	class Test1Class :TestClass
        	{        			
        		public void Add(double x)
        		{
        			sum+=x;
        			Console.WriteLine(" the sum is : {0}",sum);
        		}
        	}
        }
