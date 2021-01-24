    [CustomEditor(typeof(ConversationTrigger))]
    public class ConversationTriggerEditor : Editor
    {
        private Vector2 scrollPos;
        private SerializedProperty conversations;
        private ConversationTrigger conversationTrigger;
    
        private void OnEnable()
        {
            conversations = serializedObject.FindProperty("conversations");
            conversationTrigger = (ConversationTrigger)target;
        }
    
        public override void OnInspectorGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(250));
            DrawDefaultInspector();
            EditorGUILayout.EndScrollView();
    
            // Load the current values from the real component into the serialized copy
            serializedObject.Update();
    
            if (GUILayout.Button("Add new conversation"))
            {
                conversations.arraySize++;
            }
    
            GUILayout.Space(10);
            if (conversations.arraySize != 0)
            {
                if (GUILayout.Button("Remove conversation"))
                {
                    if (conversations.arraySize > 0) conversations.arraySize--;
                }
            }
    
            GUILayout.Space(100);
            if (GUILayout.Button("Save Conversations"))
            {
                conversationTrigger.SaveConversations();
            }
    
            GUILayout.Space(10);
            if (GUILayout.Button("Load Conversations"))
            {
                // Depending on what this does you should consider to also 
                // change it to using the SerializedProperties!
                Undo.RecordObject(conversationtrigger, "Loaded conversations from JSON");
                conversationTrigger.LoadConversations();
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    }
    
