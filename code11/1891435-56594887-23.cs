    public class CustomMenu : EditorWindow
    {
        // we can go privtae again ;)
        private static CustomMenuData data;
    
        // still called on load or recompile
        [InitializeOnLoadMethod]
        private static void OnLoad()
        {
            // if no data exists yet create and reference a new instance
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
            // fetches the values of the real instance into the serialized one
            serializedObject.Update();
    
            // get the Id field
            var id = serializedObject.FindProperty("Id");
    
            // Use PropertyField as much as possible
            // this automaticaly uses the correct layout depending on the type
            // and automatically reads and stores the according value type
            EditorGUILayout.PropertyField(id);
    
            if (GUILayout.Button("someButton"))
            {
                // Only change the value throgh the serializedProperty
                // unity marks it as dirty automatically
                // also no Repaint required - it will be done .. guess .. automatically ;)
                id.intValue += 1;
            }
    
            // finally write back all modified values into the real instance
            serializedObject.ApplyModifiedProperties();
        }
    }
