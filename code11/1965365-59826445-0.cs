 language: c#
using var fs = new FileStream(@"crg_sample.crg", FileMode.Open, FileAccess.Read);
using (StreamReader sr = new StreamReader(fs, leaveOpen:true))
{
    var line = sr.ReadLine();
    while (!string.IsNullOrWhiteSpace(line) && !line.Contains("$$$$"))
    {
        line = sr.ReadLine();
    }
}
using (BinaryReader reader = new BinaryReader(fs))
{
    // TODO: Start reading the binary data
}
