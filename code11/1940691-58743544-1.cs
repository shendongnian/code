c#
string path = @"d:/Data/A/";
            
foreach(var dir in Directory.GetDirectories(path))
{
    var files = Directory.EnumerateFiles(dir, "*.xml*", SearchOption.AllDirectories).ToList();
    var newDir = Path.Combine(dir, "YourNewFolederName");
    if (!Directory.Exists(newDir))
        Directory.CreateDirectory(newDir);
    //To copy
    files.ForEach(a => File.Copy(a, Path.Combine(newDir, Path.GetFileName(a)), true));
   //To Move
   files.ForEach(a => File.Move(a, Path.Combine(newDir,Path.GetFileName(a))));
}
Good luck.
