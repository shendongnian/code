using System;
using System.IO;
using System.Text;
namespace ReadAllLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\username\Documents\MyFile.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            string yourProductCode;
            foreach (string line in lines)
            {
                if (line .Contains("5270|"))
                {
                  string[] myLine= line .Split('|');
                  if (myLine[3] == yourProductCode)
                  {
                   // myLine[] has all your data with the product code you want
                  }
                  
                } 
            }
        }
    }
}
