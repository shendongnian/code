    static void Main()
    {
         const string t1 = "To be or not to be, that is the question.";
	     Console.WriteLine(WordCounting.CountWords1(t1));
	     Console.WriteLine(WordCounting.CountWords2(t1));
         const string t2 = "Mary had a little lamb.";
	     Console.WriteLine(WordCounting.CountWords1(t2));
	     Console.WriteLine(WordCounting.CountWords2(t2));
    }
