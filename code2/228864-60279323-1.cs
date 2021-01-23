using System;
using System.Linq;
namespace CheckStringContent
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get a password to check
            Console.WriteLine("Please input a Password: ");
            string userPassword = Console.ReadLine();
            //Check the string
            bool symbolCheck = userPassword.Any(p => !char.IsLetterOrDigit(p));
            //Write results to console
            Console.WriteLine($"Symbols are present: {symbolCheck}");     
        }
    }
}
This returns 'True' if special chars (symbolCheck) are present in the string, and 'False' if not present.
 
