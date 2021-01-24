    static void Main()
    {
        //Create a program that stops after input of 10 words
        string textt = "";
        string aSentence = "We are making a sentence of 10 words.";
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(aSentence);
            textt = textt + " " + Console.ReadLine();
            Console.WriteLine(textt);
        }
        Console.WriteLine("End of the sentence");
        Console.ReadKey();
    }
