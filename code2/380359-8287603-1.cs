    void addWord(string made){
        wordsMade.Add(made);
        if (theGame.theTrie.Search(made) == Trie.SearchResults.Found)
        {
           validWords.Add(made);
        }
    }
