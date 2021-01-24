// .NETCoreApp,Version=v3.0
Is 00ffc8 a valid color value: True
Is <h1 class="<" /> a valid XML tag: False
Is secretsauce a valid password: True
# Code
using System;
using System.Text.RegularExpressions;
using Packt.CS7;
namespace Packt.CS7
{
    public static class StringExtensions
    {
        public static bool IsValidXmlTag(this string input)
         => Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        public static bool IsValidPassword(this string input)
          => Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
        public static bool IsValidHex(this string input)
          => Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
    }
}
namespace SixSixSix
{
    class Program
    {
        static void Main(string[] args)
        {
            string hex = "00ffc8";
            Console.WriteLine($"Is {hex} a valid color value: {hex.IsValidHex()}");
            string xmlTag = @"<h1 class=""<"" />";
            Console.WriteLine($"Is {xmlTag} a valid XML tag: {xmlTag.IsValidXmlTag()}");
            string password = "secretsauce";
            Console.WriteLine($"Is {password} a valid password: {password.IsValidPassword()}");
        }
    }
}
