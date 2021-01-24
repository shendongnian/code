    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
					
    public class Program
    {
	    public static void Main()
	    {
		    var json_str = "{ \"table1\":[{\"name1\":\"data1\"},{\"name2\":\"data2\"},{\"name3\":\"data3\"}],\"table2\":[{\"name1\":\"data1\"},{\"name2\":\"data2\"},{\"name3\":\"data3\"}]}";
		    dynamic stuff = JsonConvert.DeserializeObject(json_str);
		    Console.WriteLine(stuff.table2[0].name1); // prints "data1"
		
	    }
    }
