    public Dictionary<string, GameObject> ImageByString = new Dictionary<string, GameObject>();
    public Dictionary<GameObject, string> StringByImage = new Dictionary<GameObject, string>();
    private void Start()
    {
        foreach(var pair in pairs)
        {
            ImageByString.Add(pair.word, pair.vp);
            StringByImage.Add(pair.vp, pair.word);
        }
    }
