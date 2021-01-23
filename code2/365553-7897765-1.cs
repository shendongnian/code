    string DoesBlogContainSentence(string blog, string target)
    {
       string[] blogSentences = blog.Split(new char[] {'.'});
       foreach(string sentence in blogSentences)
       {
          if(sentence.Contains(target))
          {
              return sentence;
          }
       }
       return string.Empty;
    }
