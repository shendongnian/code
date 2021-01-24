    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var jsonString = @"{ 'contacts': [{ 'id': 200, 'name': 'Ravi Tamada', 'email': 'ravi@gmail.com', 'address': 'xx-xx-xxxx,x - street, x - country', 'gender': 'male', 'phone': { 'mobile': '+91 0000000000', 'home': '00 000000', 'office': '00 000000' } }] }";
    		var data= JsonConvert.DeserializeObject<ContactList>(jsonString);
    		//Console.WriteLine(data.contacts);
    		
    		var found=data.contacts.Where(x=>x.id.ToString()=="200");
    		
    		foreach(var value in found)
    		{
    	      Console.WriteLine(value.id);
    		  Console.WriteLine(value.address);		
    		}		
    	}
    }
    
       public class Phone 
       { 
          public string mobile { get; set; } 
          public string home { get; set; } 
          public string office { get; set; } 
       } 
    
       public class Contact 
       { 
          public string id { get; set; } 
          public string name { get; set; } 
          public string email { get; set; } 
          public string address { get; set; } 
          public string gender { get; set; } 
          public Phone phone { get; set; } 
       } 
    
       public class ContactList 
       { 
          public List<Contact> contacts { get; set; } 
       }
