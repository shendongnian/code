    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    // Create model we can deserialize to
    public class FormData
    {
    	public string Name { get; set; }
    	public string Value { get; set; }
    	
    	public FormData(string name, string val)
    	{
    		Name = name;
    		Value = val;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var formData = "[{\"name\":\"question_string\",\"value\":\"\"},{\"name\":\"A\",\"value\":\"\"},{\"name\":\"B\",\"value\":\"\"},{\"name\":\"C\",\"value\":\"\"},{\"name\":\"D\",\"value\":\"\"},{\"name\":\"E\",\"value\":\"\"},{\"name\":\"correct_answer\",\"value\":\"\"},{\"name\":\"question_string\",\"value\":\"\"},{\"name\":\"A\",\"value\":\"\"},{\"name\":\"B\",\"value\":\"\"},{\"name\":\"C\",\"value\":\"\"},{\"name\":\"D\",\"value\":\"\"},{\"name\":\"E\",\"value\":\"\"},{\"name\":\"correct_answer\",\"value\":\"\"}]";
    		
    		var results = JsonConvert.DeserializeObject<List<FormData>>(formData);
    		
    		foreach (var datas in results)
    		{
    			Console.WriteLine(datas.Name);
    		}
    	}
    }
    
    /* OUTPUT:
    question_string
    A
    B
    C
    D
    E
    correct_answer
    question_string
    A
    B
    C
    D
    E
    correct_answer
    */
