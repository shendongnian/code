    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class MainClass {
      public static void Main (string[] args) {
        	const string rawLine = "\"TeamName\",\"PlayerName\",\"Position\"  \"Chargers\",\"Philip Rivers\",\"QB\"  \"Colts\",\"Peyton Manning\",\"QB\"  \"Patriots\",\"Tom Brady\",\"QB\"";
    			var parsedLines = Regex.Split(rawLine, "(?<![,])(?<=[\"])[ ]{2}(?=[\"])(?![,])");
    			parsedLines.ToList().ForEach(Console.WriteLine);
    
    			Console.WriteLine("Press [ENTER] to exit.");
    			Console.ReadLine();
      }
    }
