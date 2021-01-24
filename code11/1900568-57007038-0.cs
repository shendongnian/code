    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"{'Results':{'output1':[{'Class':'10','age':'9.06725552044283','menopause':'18.5605772106407','tumor-size':'5.62041822714077','inv-nodes':'2.50477840015836','node-caps':'5.29640554298695','deg-malig':'1.77286724180295','breast':'2.67776376618299','breast-quad':'5.61570098311485','irradiat':'4.84969010222608','Scored Labels':'1','Scored Probabilities':'0.999995118824755'}]}}";
    		var Sresponse = JsonConvert.DeserializeObject<RootObject>(json);
    		
    		foreach(var result in Sresponse.Results.output1)
    		{    
    			Console.WriteLine(result.Class);
    			Console.WriteLine(result.age);
    			Console.WriteLine(result.deg_malig);
    			Console.WriteLine(result.Scored_Labels);
    			
    		}		
    	}
    }
    
    public class Results
    {
        public List<Output1> output1 { get; set; }
    }
    
    public class RootObject
    {
        public Results Results { get; set; }
    }
    
    
    public class Output1
    {
        public string Class { get; set; }
        public string age { get; set; }
        public string menopause { get; set; }
    	
    	[JsonProperty("tumor-size")]
        public string tumor_size { get; set; }
    	
    	[JsonProperty("inv-nodes")]
        public string inv_nodes { get; set; }
    	
    	[JsonProperty("node-caps")]
        public string node_caps { get; set; }
    	
    	[JsonProperty("deg-malig")]
        public string deg_malig { get; set; }
    	
        public string breast { get; set; }
    	
    	[JsonProperty("breast-quad")]
        public string breast_quad { get; set; }
    	
        public string irradiat { get; set; }
    	
    	[JsonProperty("Scored Labels")]
        public string Scored_Labels { get; set; }
    	
    	[JsonProperty("Scored Probabilities")]
        public string Scored_Probabilities { get; set; }
    }
