    [CustomEditor(typeof(Example))]
    public class ExampleEditor : Editor
    {
        private SerializedProperty example;
    
        // initialize the Inspector
        private void OnEnable()
        {
            example = serializedObject.FindProperty("example");
        }
    
        public override void OnInspectorGUI()
        {
            // fetch current values into the serialized properties
            serializedObject.Update();
    
            // if an object is referenced draw the path
            if (example.objectReferenceValue)
            {
                var path = AssetDatabase.GetAssetPath(example.objectReferenceValue);
                EditorGUILayout.LabelField(path, EditorStyles.boldLabel);
            }
    
            // the usual reference field
            EditorGUILayout.PropertyField(example);
    
            // write back modified properties
            serializedObject.ApplyModifiedProperties();
        }
    }
