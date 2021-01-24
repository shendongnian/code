    public class CustomMenuSaver : SaveAssetsProcessor
    {
        static string[] OnWillSaveAssets(string[] paths)
        {
            // do change nothing in the paths
            // but additionally store the data in the file
            // if not exists yet create the StreamingAssets folder
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                AssetDatabase.CreateFolder("Assets", "StreamingAssets");
            }
            // serialize the values into json        v That's why I made it public
            var json = JsonUtility.ToJson(CustomMenu.data);
            // write into the file         v needs to be public as well
            File.WriteAllText(CustomMenu.FilePath, json);            
            return paths;
        }
    }
