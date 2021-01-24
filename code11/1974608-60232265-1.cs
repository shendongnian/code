    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Simple {
      public static void Main() {    
    	  
	var text = "aaaabbccaa"; //output: 4a3b2c2a
	var lista = new List<string>();
	var previousLetter = text.Substring(1,1);
	var item = string.Empty;
    foreach (char letter in text)
	{
		if (previousLetter == letter.ToString()){
			item += letter.ToString();			
		}
		else
		{
			lista.Add(item);
			item = letter.ToString();			
		}
		previousLetter = letter.ToString();
	}
	lista.Add(item);	
	foreach (var i in lista)
	     Console.WriteLine(i.Substring(1,1) + i.Select(y => y).ToList().Count().ToString());
      }
    }
