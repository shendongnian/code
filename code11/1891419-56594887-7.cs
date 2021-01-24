    private const string FileName = "CustomMenuData.asset";
    // shorthand property for getting the filepath
    public static string FilePath
    {
        get { return Path.Combine(Application.streamingAssetsPath, FileName); }
    }
    private static CustomMenuData data;
    [InitializeOnLoadMethod]
    private static void OnLoad()
    {
        // if data is null create and reference a new ScriptableObject instance
        if(!data)
        {
            // create new instance
            data = ScriptableObject.CreateInstance<CustomMenuData>();
            // store it as an asset
            AssetDatabase.CreateAsset(data, FilePath);
            
            AssetDatabase.Refresh();
        }
    }
    ...
