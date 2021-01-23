    Dictionary<string, int> _dictionary = new Dictionary<string, int>(); 
    
    private void AdjustWordCount(string word)
    {
      
      int count;
      bool success = _dictionary.TryGetValue(word, out count);
    
      if (success)
      {
        //Remove it 
        _dictionary.Remove(word);
        //Add it back in plus 1
        _dictionary.Add(word, count + 1);
      }
      else  //could not get, add it with a count of 1
      {
        _dictionary.Add(word, 1);
      }
    }
