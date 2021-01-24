      **Simple Method :** 
	    public static void DisplayFortune(string[] array, int index)
		{
			Console.WriteLine(array[index]);
		}
       **Extension Method :**
	    public static void DisplayFortune(this string[] array, int index)
		{
			Console.WriteLine(array[index]);
		}
