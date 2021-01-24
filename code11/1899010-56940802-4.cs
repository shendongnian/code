    [CustomEditor(typeof(ConversationTrigger))]
    public class ConversationTriggerEditor : Editor
    {
        private Vector2 scrollPos;
        private SerializedProperty conversations;
        private ConversationTrigger conversationTrigger;
        private ReorderableList conversationList;
    
        private void OnEnable()
        {
            conversations = serializedObject.FindProperty("conversations");
            conversationTrigger = (ConversationTrigger)target;
    
    
            conversationList = new ReorderableList(serializedObject, conversations)
            {
                displayAdd = true,
                displayRemove = true,
                draggable = true,
    
                drawHeaderCallback = rect =>
                {
    
                    EditorGUI.LabelField(new Rect(rect.x, rect.y, 100, rect.height), "Conversations", EditorStyles.boldLabel);
    
                    var newSize = EditorGUI.IntField(new Rect(rect.x + 100, rect.y, rect.width - 100, rect.height), conversations.arraySize);
    
                    conversations.arraySize = Mathf.Max(0, newSize);
                },
    
                drawElementCallback = (rect, index, isActive, isSelected) =>
                {
                    var element = conversations.GetArrayElementAtIndex(index);
    
                    var name = element.FindPropertyRelative("Name");
                    // do this for all properties
    
                    var position = EditorGUI.PrefixLabel(rect, new GUIContent(name.stringValue));
    
                    EditorGUI.PropertyField(position, name);
                },
    
                elementHeight = EditorGUIUtility.singleLineHeight
            };
        }
    
        public override void OnInspectorGUI()
        {
            // Load the current values from the real component into the serialized copy
            serializedObject.Update();
    
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(250));
    
            GUILayout.Space(10);
            conversationList.DoLayoutList();
    
            EditorGUILayout.EndScrollView();
    
            GUILayout.Space(100);
            if (GUILayout.Button("Save Conversations"))
            {
                conversationTrigger.SaveConversations();
            }
    
            GUILayout.Space(10);
            if (GUILayout.Button("Load Conversations"))
            {
                Undo.RecordObject(conversationtrigger, "Loaded conversations from JSON");
                conversationTrigger.LoadConversations();
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    }
