using System;
					
public class Program
{
	public static void Main()
	{
    string str = "abcd";
	str = str.Replace('\n',' ');
    String p = "True";
    for (int i = 1; i < str.Length; i++) {  
  
        // if element at index 'i' is less  
        // than the element at index 'i-1'  
        // then the string is not sorted  
        if (str[i] < str[i - 1]) {
			p = "false";
		} 
     
    }  
    Console.WriteLine(p);
}
}
