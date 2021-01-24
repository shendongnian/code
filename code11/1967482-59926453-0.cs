var tempFile = Path.GetTempFileName();
var linesToKeep = File.ReadLines(fileName);
// if the file is less or equal than 7000, do nothing
if(linesToKeep.Count() > 7000) {
     linesToKeep = linesToKeep.Skip(linesToKeep.Count() - 7000);
    File.WriteAllLines(tempFile, linesToKeep);
    File.Delete(fileName);
    File.Move(tempFile, fileName);
}
Of course the 7000 can be substituted by something else like a variable. 
