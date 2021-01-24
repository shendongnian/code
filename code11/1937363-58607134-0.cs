var dataLinesPerFile = 2;
var contentAsLines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
var header = contentAsLines[0];
var dataLines = contentAsLines.Skip(1);
# A. Version with writing whole file at once
// I've used foreach so that the algorithm could be used if reading line by line rather then the whole file 
List<string> lines = new List<string>();
var fileId = 0;
foreach (var line in dataLines)
{
    lines.Add(line);
    if (lines.Count() % dataLinesPerFile == 0)
    {
        WriteChunk(fileId++, header, lines);
        lines = new List<string>(); // or lines.Clear();
    }
}
if (lines.Any()) WriteChunk(fileId++, header, lines);
(...)
private static void WriteChunk(int id, string header, IEnumerable<string> lines)
{
    Console.WriteLine("");
    Console.WriteLine($"File_A{id}:");
    Console.WriteLine(header);
    Console.WriteLine(string.Join(Environment.NewLine, lines)); // File.WriteAllLines
}
# B. Version which writes line by line
var fileId = 0;
var lineCount = 0;
foreach (var line in dataLines)
{
    if (lineCount % dataLinesPerFile == 0)
    {
        //Close the file, create the new file and write the header
        Console.WriteLine(""); 
        Console.WriteLine($"File_B{fileId++}");
        Console.WriteLine(header);
    }
    Console.WriteLine(line);
    lineCount++;
}
// Close the current file
# Test
## Input
I've added a 5th line to prove the code will not loose 'stray' lines.
var content = @"A,B,C,D,E
1,2,3,4,5
12,11,8,7,6
23,23,34,1,0
23,23,32,1,0
5,5,5,5,5";
## Output
// .NETCoreApp,Version=v3.0
File_A0:
A,B,C,D,E
1,2,3,4,5
12,11,8,7,6
File_A1:
A,B,C,D,E
23,23,34,1,0
23,23,32,1,0
File_A2:
A,B,C,D,E
5,5,5,5,5
------------------
File_B0
A,B,C,D,E
1,2,3,4,5
12,11,8,7,6
File_B1
A,B,C,D,E
23,23,34,1,0
23,23,32,1,0
File_B2
A,B,C,D,E
5,5,5,5,5
