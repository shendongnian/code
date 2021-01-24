using System;
using System.IO;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"input.txt";
            string[] textFile = File.ReadAllLines(path);
            char[,] charGrid = new char[textFile.Length, textFile[0].Length];
            int i, j;
            i = 0;
            foreach (string line in textFile)
            {
                j = 0;
                foreach (char c in line)
                {
                    charGrid[i, j] = c;
                    j++;
                }
                i++;
            }
            Console.WriteLine(charGrid[0,0] +  "" + charGrid[0, 1] + "" + charGrid[0, 2]);
            Console.WriteLine(charGrid[1, 0] + "" + charGrid[1, 1] + "" + charGrid[1, 2]);
            Console.WriteLine(charGrid[2, 0] + "" + charGrid[2, 1] +  "" + charGrid[2, 2]);
            Console.ReadLine();
        }
    }
}
