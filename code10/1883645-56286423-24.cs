    public GameObject ImageByString(string word)
    {
        var output = pairs.FirstOrDefault(p => string.Equals(p.word, word));
        if(output == null)
        {
            Debug.LogErrorFormat(this, "No Image with word=\"{0}\" found!", word);
        }
        return output;
    }
    public string StringByImage(GameObject vp)
    {
        var output = pairs.FirstOrDefault(p => p.vp == vp);
        if(output == null)
        {
            Debug.LogErrorFormat(this, "No word for given GameObject {0} found!", vp.name);
        }
        return output;
    }
