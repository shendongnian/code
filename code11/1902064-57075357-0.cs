    using System;
    using System.IO;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	
    	public class Movie
    	{
        	public string Name { get; set; }
        	public int Year { get; set; }
    	}
    	
    	public static void Main()
    	{
    		Movie movie = new Movie
    		{
        		Name = "Bad Boys",
        		Year = 1995
    		};
    
    		// serialize JSON to a string and then write string to a file
    		string json =  JsonConvert.SerializeObject(movie);
    		Console.WriteLine(json);
    		File.WriteAllText("your.path.here", json);
    		
    		string json2 = File.ReadAllText("your.path.here");
    		Movie movie2 = JsonConvert.DeserializeObject<Movie>(json);
    		Console.WriteLine(movie2.Name);
    	}
    }
