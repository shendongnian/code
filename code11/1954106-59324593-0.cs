    [CustomEditor(typeof(YourClass))]
    public class YourClassEditor : Editor
    {
        SerializedProperty myObject;
    
        // initialize the Inspector
        private void OnEnable()
        {
            myObject = serializedObject.FindProperty("myObject");
        }
        public override void OnInspectorGUI()    
        {
            // fetch current values into the serialized properties
            serilaizedObject.Update();
    
            // if an object is referenced draw the path
            if(myObject.objectReference)
            {
                var path = AssetDatabase.GetAssetPath(myObject);
                EditorGUILayout.LabelField(path, EditorStyles.boldLabel);
            }
            // the usual reference field
            EditorGUILayout.PropertyField(myObject);
    
            // write back modified properties
            serializedObject.ApplyModifiedProperties();
        }
    }
