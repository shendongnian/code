    public class CustomMenu : EditorWindow
    {
        // Instead of having the field values directly as static fields
        // rather store the information in a proper serializable class
        [Serializable]
        private class CustomMenuData
        {
            public int Id;
        }
        // made this publlic for the saving process (see below)
        public static readonly CustomMenuData data = new CustomMenuData();
        // InitializeOnLoadMethod makes this method being called everytime
        // you load the project in the editor or after re-compilation
        [InitializeOnLoadMethod]
        private static void OnLoad()
        {
            if (!File.Exists(FilePath)) return;
            // read in the data from the json file
            JsonUtility.FromJsonOverwrite(File.ReadAllText(FilePath), data);
        }
        ...
    }
