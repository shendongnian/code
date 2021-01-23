    namespace Homework
    {
    	class Recursion
    	{
    		static string[] nameList = new string[5];
    		static void Main(string[] args)
    		{
    			AssignNames(0);
    			Console.WriteLine("The names are:");
    			foreach(string name in nameList)
    			{
    				Console.WriteLine(name);
    			}
    			Console.ReadKey();
    
    		}
    
    		static void AssignNames(int index)
    		{
    			if (index == nameList.Length) return;
    			Console.Write("Enter name #{0}: ", index + 1);
    			nameList[index] = Console.ReadLine();
    			AssignNames(index + 1);
    		}
    	}
    }
