     static void Main(string[] args)
        {
           string input = Console.ReadLine();
           string[] words = input.Split(' ');
    //        words = new string[10];
    
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Console.ReadLine();
                Console.WriteLine(words[i]);
                Console.WriteLine("test");
            }     
        }
