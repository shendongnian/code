using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.AsyncTestClient();
            var result = client.Operation();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
