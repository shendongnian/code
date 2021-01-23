    public static void Main(string[] args)
    {
        PigLatin pl = new PigLatin();
        string englishSentence = "";
        string pigLatinSentence = "";
    
        Console.WriteLine("Enter a sentence to convert into Pig Latin.\n");
    
        englishSentence = Console.ReadLine();
    
        pigLatinSentence = pl.TranslateFromEnglish(englishSentence);
    
        console.WriteLine(string.Format("{0}\n", pigLatinSentence));  
    }
