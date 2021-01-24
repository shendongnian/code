 csharp
using System;
using System.IO;
private void IncrementInt32ValueInFile(string filePath)
{
    var currentFileText = File.ReadAllText(filePath);
    if (int.TryParse(currentFileText, out int integerValue))
    {
        File.WriteAllText(filePath, Convert.ToString(++integerValue));
    }
    throw new Exception($"Incorrect file content. Path: {filePath}"); // If value in file can't be parsed as integer
}
