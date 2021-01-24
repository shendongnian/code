    public Dictionary<string, GameObject> ImageByString = new Dictionary<string, GameObject>();
    private void Start()
    {
        foreach(var pair in pairs)
        {
            ImageByString.Add(pair.word, pair.vp);
        }
    }
