var lines = System.IO.File.ReadAllLines("path");
string[] Split(string line) => line.Split(new[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
var line0 = Split(lines[0]);
var line1 = Split(lines[1]);
var line2 = Split(lines[2]);
// Using anonymous types - in real life you probably want concrete classes. 
var board = new { N = Int32.Parse(line0[1]), M = Int32.Parse(line0[2])};
var turtle = new { X = Int32.Parse(line1[1]), Y = Int32.Parse(line1[2]), Dir = line2[1] };
For the test I used:
 var text = @"BoardSize: 4, 5
              TurtlePos: 2, 3
              TurtleDir: North";
var lines = text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries); 
