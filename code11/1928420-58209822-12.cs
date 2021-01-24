    static public void StringHelperTest()
    {
      string str1 = null;
      string str2 = "";
      string str3 = "A";
      string str4 = "TEST";
      string str5 = "TEST STRING, FOR  STACK OVERFLOW!!";
      Console.WriteLine(str1.LastLetterOfWordsToLower());
      Console.WriteLine(str2.LastLetterOfWordsToLower());
      Console.WriteLine(str3.LastLetterOfWordsToLower());
      Console.WriteLine(str4.LastLetterOfWordsToLower());
      Console.WriteLine(str5.LastLetterOfWordsToLower());
    }
