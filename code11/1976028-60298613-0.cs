var memStream = new MemoryStream();
using (var sw = new StreamWriter(memStream, new UTF8Encoding(false), 4194304 /* 4 MiB */, leaveOpen: true))
{
    var str = new string(Enumerable.Repeat(' ', 10240 /* 10 * KiB */).ToArray());
    Console.WriteLine(str.Length);
    Console.WriteLine(Encoding.UTF8.GetBytes(str).Length);
    sw.Write(str);
    sw.Flush();
    Console.WriteLine(memStream.Length);
}
