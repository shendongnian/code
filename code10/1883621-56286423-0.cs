    public Dictionary<string, GameObject> ImageByString = new Dictionary<string, GameObject>();
    private void Start()
    {
        // at least have an "emergency" check and use the smaller list count
        var count = Mathf.Min(vp.Count, word.Count);
        for(var i = 0; i < count; i++)
        {
            ImageByString.Add(word[i], vp[i]);
        }
    }
