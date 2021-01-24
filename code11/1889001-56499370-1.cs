    using System.Linq;
    using System.IO;
    
    ...
    
    string csv = "csv path";
    // Skip the one with the names
    string[] items = File.ReadAllLines(csv).Skip(1);
    foreach(var item in items)
    {
        string oldname = item.Split(';')[0];
        string newname = item.Split(';')[1];
        if(Directory.Exists(oldname) && !Directory.Exists(newname))
            Directory.Move(oldname, newname);
    }
