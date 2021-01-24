 c#
/* write a dummy file as raw UTF-8; this is just test data that looks like:
1°
2²
3
*/
File.WriteAllBytes("test.txt", new byte[] {
         0x31, 0xC2, 0xB0, 0x0D, 0x0A,
         0x32, 0xC2, 0xB2, 0x0D, 0x0A, 0x33 });
// use the TextReader API to consume the file
using (var reader = new StreamReader("test.txt", Encoding.UTF8))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
Note, however, that it is easier to use `foreach` with `File.ReadLines("test.txt", Encoding.UTF8)`:
 c#
foreach(var line in File.ReadLines("test.txt", Encoding.UTF8))
{
    Console.WriteLine(line);
}
