    string[] words = sentence.split(new char[] {' '});
    IList<string> sentenceParts = new List<string>();
    sentenceParts.Add(string.Empty);
    int partCounter = 0;    
    foreach (word in words)
    {
      if(sentenceParts[partCounter] + word > myLimit)
      {
         partCounter++;
         sentenceParts.Add(string.Empty);
      }
      sentenceParts[partCounter] += word + " ";
    }
