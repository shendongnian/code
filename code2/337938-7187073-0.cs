    using System;
    
    class Program
    {
        static void Main()
        {
            byte[] bytes = { 32, 32, 32, 10 };
            string text  = "hello\n";
            char[] characterArray = System.Text.Encoding.ASCII.GetString(bytes).ToCharArray();
    
            for (int i = 0; i < characterArray.Length; ++i) {
                if (IsUnixNewline(characterArray, i)) {
                    Console.WriteLine("Found Unix newline in 'bytes'.");
                    break;
                }
            }
            characterArray = text.ToCharArray();
            for (int i = 0; i < characterArray .Length; ++i) {
                if (IsUnixNewline(characterArray, i)) {
                    Console.WriteLine("Found Unix newline in 'text'.");
                    break;
                }
            }
        }
    
        static bool IsUnixNewline(char[] array, int index)
        {
            return array[index] == '\n' && (index == 0 || array[index - 1] != '\r');
        }
    }
