    void addWord(string newWordMade){
        wordsMade.Add(newWordMade);
        if (theGame.theTrie.Search(newWordMade) == Trie.SearchResults.Found)
        {
           validWords.Add(newWordMade);
        }
    }
