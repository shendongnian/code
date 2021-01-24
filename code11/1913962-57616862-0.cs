csharp
var linesRead = System.IO.File.ReadAllLines(@"test.txt"); //Just a bunch of lines
foreach (var line in linesRead)
{
    if (!string.IsNullOrEmpty(line) && line[0] == '5')
    {
        //Do stuff
    }
}
