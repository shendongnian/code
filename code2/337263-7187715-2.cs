     namespace RefTest
     {
     	class Program
     	{
     		static void Test(object o) { GC.KeepAlive(o); }
     
     		static void Main(string[] args)
     		{
     			object temp = args;
     			Test(temp);
     		}
     	}
     }
