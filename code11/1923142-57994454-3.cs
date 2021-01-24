using System;
namespace HexConverter
{
    class HexConverter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I/O Hex Converter");
            GetUserInput();
            Console.ReadLine();
        }
        private static void GetUserInput()
        {
            string userInput;
            int candidateNum;
            do
            {
                Console.WriteLine("Enter Int Value: ");
                userInput = Console.ReadLine();
            } while(!int.TryParse(userInput, out candidateNum));
            Console.WriteLine("{0} Converted to Hex is: {0:X}", candidateNum);
        }
    }
}
 
