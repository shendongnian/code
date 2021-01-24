C#
static void CensorSelectedWords(string _sentence, int _wordCount)
{
    string astr;
    string[] words = new string[_wordCount];
    string[] splitSentence = new string[_wordCount];
    for (int i = 0; i < words.Length; i++)
    {
        Console.WriteLine("Type in the words you wish to be censored: ");
        words[i] = Console.ReadLine();
        astr = "";
        for (int j = 0; j < words[I].Length; j++)
            astr += "*";
        _sentence = _sentence.Replace(word[i], astr);
    }
    Console.WriteLine(_sentence); 
}
