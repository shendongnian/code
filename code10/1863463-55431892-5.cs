    [CustomEditor(typeof(DialogueTrigger))]
    public class DialogueTriggerEditor : Editor
    {
        private SerializedProperty _dialogues;
        private SerializedProperty _conversations;
    
        private void OnEnable()
        {
            _conversations = serializedObject.FindProperty("conversation");
        }
    
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
    
            serializedObject.Update();
    
            _conversations.arraySize = EditorGUILayout.IntField("Conversation Size", _conversations.arraySize);
    
            for (int x = 0; x < _conversations.arraySize; x++)
            {
                var conversation = _conversations.GetArrayElementAtIndex(x);
    
                var id = conversation.FindPropertyRelative("I'd");
                EditorGUILayout.PropertyField(Id);
    
                var dialogues = conversation.FindPropertyRelative("Dialogues");
    
                dialogues.arraySize = EditorGUILayout.IntField("Dialogues size", dialogues.arraySize);
    
                for (int i = 0; i < _dialogues.arraySize; i++)
                {
                    var dialogue = _dialogues.GetArrayElementAtIndex(i);
                    EditorGUILayout.PropertyField(dialogue, new GUIContent("Dialogue " + i), true);
                }
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    }
