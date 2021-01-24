using System;
using System.IO;
using System.Text;
namespace ReadAllLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Jano\Documents\thermopylae.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            string yourProductCode;
            foreach (string line in lines)
            {
                if (line .Contains("5270|"))
                {
                  string[] myLine= line .Split('|');
                  yourProductCode = mystring[3];
                } 
            }
        }
    }
}
