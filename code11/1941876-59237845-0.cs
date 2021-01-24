    Console.WriteLine("Welcome to the game guess the word");
    Console.WriteLine("First word will be:");
    Console.Write("City located in Europe in EX Yugoslavia is:");
    string userWordInput = Console.ReadLine();
    int i = 0;
    do
    {
        for (i = 0; i < 5; i++)
        {
            Console.WriteLine("Your input is wrong");
        }
    } while (Console.ReadLine() != "Sarajevo");
