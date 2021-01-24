using System;
using System.IO;
class Test
{
    public static void Main()
    {
        var filepath = @"myfile.txt";
        // Read all lines.
        var allLines = File.ReadAllLines(filepath);
        // Modify your text here.
        foreach (var line in allLines)
        {
            // Parse the line and separate its components with delimiters ':', '"' and '='.
            var components = line.Split(new char[]{':', '"', '=',});
            // Change all X:"value_i"=Y to X:"value_i"=5.
            components[2] = "5";
        }
        
        // Write all lines.
        File.WriteAllLines(filepath, allLines);
    }
}
