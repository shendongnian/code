    using System.IO;
    using System.Linq;
    public string[] ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName);
    }
    public string[] QueryFile(string fileName, string productCode, string lineStarter)
    {
        var data = ReadFile(fileName);
        return data.Where(x => x.StartsWith(lineStarter) && x.Contains(productCode)).ToArray();
    }
