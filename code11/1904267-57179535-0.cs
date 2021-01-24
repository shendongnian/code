c#
Console.WriteLine("a: " + string.Join("-", Encoding.Unicode.GetBytes("a").Select(s => s.ToString("X2"))));
Console.WriteLine("€: " + string.Join("-", Encoding.Unicode.GetBytes("€").Select(s => s.ToString("X2"))));
You have to check every char in your string and choose only those which match your requirement.
c#
static void Main(string[] args)
{
    string str = "abc€def!\"§$%&/()=?`";
    
    var enc = Encoding.GetEncoding(1252);
    
    Console.WriteLine("All:     " + str);
    // Select all chars which have a total value below 128
    IEnumerable<char> chars = str.Where(s => ConvertLittleEndian(enc.GetBytes(s + "")) < 128);
    // reassamble string
    Console.WriteLine("Reduced: " + String.Concat(chars));
}
static ulong ConvertLittleEndian(byte[] array)
{
    int pos = 0;
    ulong result = 0;
    foreach (byte by in array)
    {
        result |= ((ulong)by) << pos;
        pos += 8;
    }
    return result;
}
The static method `ConvertLittleEndian()` is a copy of the first answer from this question:
https://stackoverflow.com/questions/6165171/convert-byte-array-to-int
