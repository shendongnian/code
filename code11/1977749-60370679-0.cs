    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		var jsonString = @"'{'\'itemList\':[{\'id\':1,\'name\':\'Item 1 Name\'},{\'id\':2,\'name\':\'Item 2 Name\'}],'listInfo':{'info1':1,'info2':'bla'}}'";		
    		var unescaptedstring=Regex.Unescape(jsonString);
    		//Remove the extra characters at the first,second and last index of the origial string
    		var index = unescaptedstring.IndexOf('\'', unescaptedstring.IndexOf('\'') + 0);
    		var ouput = string.Concat(unescaptedstring.Substring(0,index), "", unescaptedstring.Substring(index + 1));
    		var index1 = ouput.IndexOf('\'', ouput.IndexOf('\'') + 1);
    		var ouput1 = string.Concat(ouput.Substring(0,index1), "", ouput.Substring(index1 + 1));
    		var index2 = ouput1.IndexOf('\'', ouput1.LastIndexOf('\''));
    		var ouput2 = string.Concat(ouput1.Substring(0,index2), "", ouput1.Substring(index2 + 1));
    		
    		//Console.WriteLine(ouput2);	
    		
    		//Now deserialze as required:
    		
    		var data= JsonConvert.DeserializeObject<RootObject>(ouput2);
    
    		foreach(var item in data.itemList)
    		{
    			Console.WriteLine(item.id);	
    			Console.WriteLine(item.name);
    		}
    		
    	}
    }
    
    public class ItemList
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    public class ListInfo
    {
        public int info1 { get; set; }
        public string info2 { get; set; }
    }
    
    public class RootObject
    {
        public List<ItemList> itemList { get; set; }
        public ListInfo listInfo { get; set; }
    }
    
