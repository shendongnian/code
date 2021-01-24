    using UnityEditor;
    using UnityEngine;
    public class EditorUtils
    {
        [MenuItem("Tools/Create SO")]
        private static void CreateSO()
        {
            GenerateAndSaveSOClass();
            ShouldCreateSO = true;
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
        private static bool ShouldCreateSO
        {
            get { return EditorPrefs.GetBool("should_create", false); }
            set { EditorPrefs.SetBool("should_create", value);}
        }
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            if (ShouldCreateSO)
            {
                ShouldCreateSO = false;
                var so = ScriptableObject.CreateInstance("MyClassName");
                var path = "Assets/SO.asset";
                AssetDatabase.CreateAsset(so, path);
            }
        }
        private static void GenerateAndSaveSOClass()
        {
            // TODO: generate and save class
        }
    }
