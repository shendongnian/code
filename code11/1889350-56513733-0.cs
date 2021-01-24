csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
public class Program
{
    static Dictionary<string, int> CountChunks(string data, int chunkLength)
    {
        var chunkCounts = new Dictionary<string, int>();
        var l = data.Length;
        for (var i = 0; i < l - chunkLength; i++)
        {
            var chunk = data.Substring(i, chunkLength);
            int count = 0;
            chunkCounts.TryGetValue(chunk, out count);
            chunkCounts[chunk] = count + 1;
        }
        return chunkCounts;
    }
    static void Main(string[] args)
    {
        var time = new Stopwatch();
        time.Start();
        var fileName = "10.txt";
        var data = string.Join("", File.ReadAllText(fileName));
        var chunkCounts = CountChunks(data, 15);
        using (var sw = new StreamWriter(fileName.Substring(0, fileName.Length - 4) + "Results.txt"))
        {
            foreach (var pair in chunkCounts)
            {
                sw.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
        time.Stop();
        Console.WriteLine("Time : " + time.Elapsed);
    }
}
The output `10Results.txt` looks something like
011100000111100 - 34
111000001111000 - 37
110000011110001 - 27
100000111100010 - 28
000001111000101 - 37
000011110001010 - 36
000111100010100 - 44
001111000101001 - 35
011110001010011 - 41
111100010100110 - 42
etc.
