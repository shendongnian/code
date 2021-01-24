lang=csharp
using Newtonsoft.Json;
using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic x = JsonConvert.DeserializeObject("[{key: '1001', value: 'test'}, {key: '1002', value: 'test2'}, ]");
            Console.WriteLine(x[0].key);
            Console.WriteLine(x[0].value);
            Console.WriteLine(x[1].key);
            Console.WriteLine(x[1].value);
            Console.ReadLine();
        }
    }
}
