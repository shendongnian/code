string[] lines = File.ReadAllLines(INILoc);
List<string> linesToWrite = new List<string>();
foreach(string line in lines)
{
    linesToWrite.Add(line);
    if (line.Contains("[names]")) break;
}
File.WriteAllLines(INILoc, linesToWrite);
