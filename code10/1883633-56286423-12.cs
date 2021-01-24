    public GameObject ImageByString(string word)
    {
        var output = pairs.FirstOrDefault(p => string.Equals(p.word, word));
        if(output == null)
        {
            Debug.LogErrorFormat(this, "No Image with word=\"{0}\" found!", word);
        }
        return output;
    }
