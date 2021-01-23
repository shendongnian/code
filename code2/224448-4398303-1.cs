    string[] words = sentence.Split(new char[] {' '});
    IList<string> sentenceParts = new List<string>();
    sentenceParts.Add(string.Empty);
    int partCounter = 0;    
    foreach (var word in words)
    {
      if(sentenceParts[partCounter].Length + word.Length > myLimit)
      {
         partCounter++;
         sentenceParts.Add(string.Empty);
      }
      sentenceParts[partCounter] += word + " ";
    }
