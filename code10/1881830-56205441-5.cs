    using UnityEditor;
    ...
    [CustomEditor(typeof(Myscript))]
    public class MyScriptEditor : GridLayoutGroupEditor
    {
        private SerializedProperty ishhh;
    
        // Called when the Inspector is loaded
        // Usually when the according GameObject gets selected in the hierarchy
        private void OnEnable ()
        {
            // "Link" the SerializedProperty to a real serialized field
            // (public fields are serialized automatically)
            ishhh = serializedObject.FindProperty("ishhh");
        }
    
        // Kind of the Inspector's Update method
        public override void OnInpectorGUI ()
        {
            // Draw the default inspector
            base.OnInspectorGUI();
            
            // Fetch current values into the serialized properties
            serializedObject.Update();
    
            // Automatically uses the correct field drawer according to the property type
            EditorGUILayout.PropertyField(ishhh);
            // Write back changed values to the real component
            serializedObject.ApplyModifiedProperties();
        }
    }
