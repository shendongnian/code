    private string GetKeyByValue(string searchValue)
    {
        foreach (DictionaryEntry entry in myHashTable)
        {
            if (entry.Value.ToString().Equals(searchValue))
            {
                return entry.Key.ToString();                
            }
        }
        return string.Empty;
    }
