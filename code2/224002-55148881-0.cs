    static class ArrayExtensions
    {
    	public static int IndexOf<T>(this T[] array, T value)
        {
     		return Array.IndexOf(array, value);
        }	
    }
    
    // Usage
    int[] array = { 9,8,7,6,5 };
		
    var index = array.IndexOf(7);
    Console.WriteLine(index); // Prints "2"
    
