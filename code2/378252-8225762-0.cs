    class Program
    {
        static void Main(string[] args)
        {
             string input = Console.ReadLine();
             string[] words = input.Split(' ');
             foreach (string word in words)
             {
                  Console.WriteLine(word);
                  Console.WriteLine("test");
             }     
        }
    }
