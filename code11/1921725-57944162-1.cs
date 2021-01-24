    
    [CustomEditor(typeof(ScriptableObjects.OBJ))]
    public class OBJEditor: UnityEditor.Editor 
    {
        private SerializedProperty offset;
    
        private void OnEnable()
        {
            // Link the properties
            offset = serializedObject.FindProperty("Offset");
        }
    
        public override void OnInspectorGUI() 
        {
            DrawDefaultInspector();
    
            // Load the real class values into the serialized copy
            serializedObject.Update();
    
            // Automatically uses the according PropertyDrawer for the type
            EditorGUILayout.PropertyField(offset);
    
            ...
    
            // Write back changed values and evtl mark as dirty and handle undo/redo
            serializedObject.ApplyModifiedProperties();
        }
    }
