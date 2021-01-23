    using System.Text.RegularExpressions;
    ...
    string input = GetArticle(); // or however you get your input
    
    input = Regex.Replace(input, @"[^0-9\w\s]", string.Empty);
    
    // not sure what your separators but you can always
    // reduce multiple spaces to a single space and just split
    // on the single space
    var articleWords = new Queue<string>(input.Split( ... ));
    
    do {
         checkedWord = articleWords.Dequeue();
         
         // put your conditional grouping here if you want
         if(!_spellChecker.CheckWord(checkedWord)) {
              // only update "correct" if necessary - writes are more expensive =)
              // although with the "break" below you shouldn't need "correct" anymore
              // correct = false;
              
              // in case you want to raise an event - it's cleaner =)
              OnSpellingError(checkWord);
              
              // if you want to stop looping because of the error
              break;
         }
    }
    while(articleWords.Count > 0);
