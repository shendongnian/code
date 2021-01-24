    [CustomEditor(typeof(Test))]
    public class TestEditor : Editor
    {
        public override void OnInpectorGUI ()
        {
            // Draw the default inspector
            DrawDefaultInspector();
            EditorGUILayout.Space();
            // Add a button for opening the EditorWindow and pass in the reference
            if(GUILayout.Button("Open EditorWindow"))
            {
                TestEditorWindow.ConversationsSystem((Test) target);
            }
        }
    }
