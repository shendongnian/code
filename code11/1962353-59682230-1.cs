    using System.IO;
    using System.Linq;
    public string[] ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName);
    }
    public string QueryFile(string fileName, string productCode)
    {
        var data = ReadFile(fileName);
        return data.Where(x => x.Contains(productCode)).ToString().Split('|')[0];
    
    }
