    using System;
    using System.Linq;
    using System.Xml.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    
    		Find("Apple");
    		Find("Banana,raw");	 
    		Find("Banana, ");
    	}
    	
    	public static void Find(string input)
    	{
    		var xml = @"<Properties>
    			<prop1 Name = ""Apple"" Defaultvalue=""red"">
    				 <childprop Name = ""special"" Value=""pink"" >
    				 </childprop>
    			</prop1>
    			<prop1 Name = ""Orange""  Defaultvalue=""orange"">     
    			</prop1>
    			<prop1 Name = ""Banana"" Defaultvalue=""yellow"">
    				<childprop Name = ""raw"" Value=""green"" >
    				</childprop>
    				<childprop Name = ""special"" Value=""red"" >
    				</childprop>
    			</prop1>  
    		</Properties>";
    			
    		var doc = XElement.Parse(xml);
    		
    		var keywords = input.Split(',');
    		
    		XElement match = null;
    		foreach (var key in keywords){
    			var node = (from n in (match??doc).Descendants()
    				where (string)n.Attribute("Name") == key
    				select n).FirstOrDefault();
    			match = node??match;
    		}
    		if (match != null)
    			Console.WriteLine(((string) match.Attribute("Defaultvalue"))??((string)match.Attribute("Value")));
    		else
    			Console.WriteLine("Nothing Found.");
    	}
    }
