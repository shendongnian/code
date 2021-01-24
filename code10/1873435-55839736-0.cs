using System.IO;
class Test
{
    public static void Main()
    {
        var filepath = @"myfile.txt";
        // Read all lines.
        var allLines = File.ReadAllLines(filepath);
        // Modify your text here
        foreach (var line in allLines)
        {
            // Parse the line and separate its components.
            var components = line.Split(new char[]{':', '"', '=',});
            components[2] = "5";
        }
        
        // Write all lines
        File.WriteAllLines(filepath, allLines);
    }
}
