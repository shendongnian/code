    using System.IO;
    using UnityEditor;
    using UnityEngine;
    
    public class CustomMenu : EditorWindow
    {
        private const string FileName = "Example.txt";
        // shorthand property for getting the filepath
         private string FilePath
         {
             get { return Path.Combine(Application.streamingAssetsPath, FileName); }
         }
    
        private static int id = 10000;
    
        // Serialized backing field for storing the value
        [SerializeField] private int _id;
    
        [MenuItem("Custom/CustomMenu")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            CustomMenu window = (CustomMenu)EditorWindow.GetWindow(typeof(CustomMenu));
    
            if (File.Exists(FilePath))
            {
                // read the file content
                var json = File.ReadAllText(FilePath)
                // If the file exists deserialize the JSON and read in the values
                // for only one value ofcourse this is overkill but for multiple values
                // this is easier then parsing it "manually"
                JsonUtility.FromJsonOverwrite(json, window);
    
                // pass the values on into the static field(s)
                id = window._id;
            }
    
            window.Show();
        }
    
        private void OnGUI()
        {
            id = EditorGUILayout.IntField(id);
    
            if (GUILayout.Button("someButton"))
            {
                id++;
                Repaint();
                EditorUtility.SetDirty(this);
    
                // do everything in oposide order
                // first fetch the static value(s) into the serialized field(s)
                _id = id;
    
                // if not exists yet create the StreamingAssets folder
                if (!Directory.Exists(Application.streamingAssetsPath))
                {
                    AssetDatabase.CreateFolder("Assets", "StreamingAssets");
                }
    
                // serialize the values into json
                var json = JsonUtility.ToJson(this);
                // write into the file
                File.WriteAllText(FilePath, json);
                // reload the assets so the created file becomes visible
                AssetDatabase.Refresh();
            }
        }
    }
