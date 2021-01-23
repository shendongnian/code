    static void ReplaceWords()
    {
      string inputFileName = null;
      string outputFileName = null;
      // this dictionary maps each single word that can be found
      // in any keyphrase to a list of the keyphrases that contain it.
      IDictionary<string, IList<string>> singleWordMap = null;
      using (var source = new StreamReader(inputFileName))
      {
        using (var target = new StreamWriter(outputFileName))
        {
          string line;
          while ((line = source.ReadLine()) != null)
          {
            // first, we split each line into a single word - a unit of search
            var singleWords = SplitIntoWords(line);
            var result = new StringBuilder(line);
            // for each single word in the line
            foreach (var singleWord in singleWords)
            {
              // check if the word exists in any keyphrase we should replace
              // and if so, get the list of the related original keyphrases
              IList<string> interestingKeyPhrases;
              if (!singleWordMap.TryGetValue(singleWord, out interestingKeyPhrases))
                continue;
              Debug.Assert(interestingKeyPhrases != null && interestingKeyPhrases.Count > 0);
              // then process each of the keyphrases
              foreach (var interestingKeyphrase in interestingKeyPhrases)
              {
                // and replace it in the processed line if it exists
                result.Replace(interestingKeyphrase, GetTargetValue(interestingKeyphrase));
              }
            }
            // now, save the processed line
            target.WriteLine(result);
          }
        }
      }
    }
    private static string GetTargetValue(string interestingKeyword)
    {
      throw new NotImplementedException();
    }
    static IEnumerable<string> SplitIntoWords(string keyphrase)
    {
      throw new NotImplementedException();
    }
