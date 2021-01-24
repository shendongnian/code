    public class CustomMenu : EditorWindow
    {
        private static CustomMenuData data;
    
        [InitializeOnLoadMethod]
        private static void OnLoad()
        {
            if (!data)
            {
                data = CreateInstance<CustomMenuData>();
    
                AssetDatabase.CreateAsset(data, "Assets/CustomMenuData.asset");
                AssetDatabase.Refresh();
            }
        }
    
        [MenuItem("Custom/CustomMenu")]
        private static void Init()
        {
            // Get existing open window or if none, make a new one:
            var window = (CustomMenu)EditorWindow.GetWindow(typeof(CustomMenu));
    
            window.Show();
        }
    
        private void OnGUI()
        {
            // Note that going through the SerializedObject
            // and SerilaizedProperties is the better way of doing this!
            // 
            // Not only will Unity automatically handle the set dirty and saving
            // but it also automatically adds Undo/Redo functionality!
            var serializedObject = new SerializedObject(data);
            serializedObject.Update();
    
            var id = serializedObject.FindProperty("Id");
    
            EditorGUILayout.PropertyField(id);
    
            if (GUILayout.Button("someButton"))
            {
                id.intValue += 1;
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    }
