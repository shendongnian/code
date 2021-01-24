    [CustomEditor(typeof(ConversationTrigger))]
    public class ConversationTriggerEditor : Editor
    {
        private ConversationTrigger _conversationTrigger;
    
        [SerializeField] private ReorderableList conversationsList;
    
        private SerializedProperty _conversations;
    
        private int _currentlySelectedConversationIndex = -1;
    
        private readonly Dictionary<string, ReorderableList> _dialoguesListDict = new Dictionary<string, ReorderableList>();
        private readonly Dictionary<string, ReorderableList> _sentencesListDict = new Dictionary<string, ReorderableList>();
    
        private void OnEnable()
        {
            _conversationTrigger = (ConversationTrigger)target;
            _conversations = serializedObject.FindProperty("conversations");
    
            conversationsList = new ReorderableList(serializedObject, _conversations)
            {
                displayAdd = true,
                displayRemove = true,
                draggable = true,
    
                drawHeaderCallback = DrawConversationsHeader,
    
                drawElementCallback = DrawConversationsElement,
    
                onAddCallback = (list) =>
                {
                    SerializedProperty addedElement;
                    // if something is selected add after that element otherwise on the end
                    if (_currentlySelectedConversationIndex >= 0)
                    {
                        list.serializedProperty.InsertArrayElementAtIndex(_currentlySelectedConversationIndex + 1);
                        addedElement = list.serializedProperty.GetArrayElementAtIndex(_currentlySelectedConversationIndex + 1);
                    }
                    else
                    {
                        list.serializedProperty.arraySize++;
                        addedElement = list.serializedProperty.GetArrayElementAtIndex(list.serializedProperty.arraySize - 1);
                    }
    
                    var name = addedElement.FindPropertyRelative("Name");
                    var foldout = addedElement.FindPropertyRelative("Foldout");
                    var dialogues = addedElement.FindPropertyRelative("Dialogues");
    
                    name.stringValue = "";
                    foldout.boolValue = true;
                    dialogues.arraySize = 0;
                },
    
                elementHeightCallback = (index) =>
                {
                    return GetConversationHeight(_conversations.GetArrayElementAtIndex(index));
                }
            };
        }
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
    
            // if there are no elements reset _currentlySelectedConversationIndex
            if (conversationsList.serializedProperty.arraySize - 1 < _currentlySelectedConversationIndex) _currentlySelectedConversationIndex = -1;
    
            conversationsList.DoLayoutList();
    
            if (GUILayout.Button("Save Conversations"))
            {
                _conversationTrigger.SaveConversations();
            }
    
            if (GUILayout.Button("Load Conversations"))
            {
                Undo.RecordObject(_conversationTrigger, "Loaded conversations from JSON");
                _conversationTrigger.LoadConversations();
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    
        #region Drawers
    
        #region List Headers
    
        private void DrawConversationsHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Conversations");
        }
    
        private void DrawDialoguesHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Dialogues");
        }
    
        private void DrawSentencesHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Sentences");
        }
    
        #endregion List Headers
    
        #region Elements
    
        private void DrawConversationsElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (isActive) _currentlySelectedConversationIndex = index;
    
            var conversation = _conversations.GetArrayElementAtIndex(index);
    
            var position = new Rect(rect);
    
            var name = conversation.FindPropertyRelative("Name");
            var foldout = conversation.FindPropertyRelative("Foldout");
            var dialogues = conversation.FindPropertyRelative("Dialogues");
            string dialoguesListKey = conversation.propertyPath;
    
            EditorGUI.indentLevel++;
            {
                // make the label be a foldout
                foldout.boolValue = EditorGUI.Foldout(new Rect(position.x, position.y, 10, EditorGUIUtility.singleLineHeight), foldout.boolValue, foldout.boolValue ? "" : name.stringValue);
    
                if (foldout.boolValue)
                {
                    // draw the name field
                    name.stringValue = EditorGUI.TextField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), name.stringValue);
                    position.y += EditorGUIUtility.singleLineHeight;
    
                    if (!_dialoguesListDict.ContainsKey(dialoguesListKey))
                    {
                        // create reorderabl list and store it in dict
                        var dialoguesList = new ReorderableList(conversation.serializedObject, dialogues)
                        {
                            displayAdd = true,
                            displayRemove = true,
                            draggable = true,
    
                            drawHeaderCallback = DrawDialoguesHeader,
    
                            drawElementCallback = (convRect, convIndex, convActive, convFocused) => { DrawDialoguesElement(_dialoguesListDict[dialoguesListKey], convRect, convIndex, convActive, convFocused); },
    
                            elementHeightCallback = (dialogIndex) =>
                            {
                                return GetDialogueHeight(_dialoguesListDict[dialoguesListKey].serializedProperty.GetArrayElementAtIndex(dialogIndex));
                            },
    
                            onAddCallback = (list) =>
                            {
                                list.serializedProperty.arraySize++;
                                var addedElement = list.serializedProperty.GetArrayElementAtIndex(list.serializedProperty.arraySize - 1);
    
                                var newDialoguesName = addedElement.FindPropertyRelative("Name");
                                var newDialoguesFoldout = addedElement.FindPropertyRelative("Foldout");
                                var sentences = addedElement.FindPropertyRelative("Sentences");
    
                                newDialoguesName.stringValue = "";
                                newDialoguesFoldout.boolValue = true;
                                sentences.arraySize = 0;
                            }
                        };
                        _dialoguesListDict[dialoguesListKey] = dialoguesList;
                    }
    
                    _dialoguesListDict[dialoguesListKey].DoList(new Rect(position.x, position.y, position.width, position.height - EditorGUIUtility.singleLineHeight));
                }
    
            }
            EditorGUI.indentLevel--;
        }
    
        private void DrawDialoguesElement(ReorderableList list, Rect rect, int index, bool isActive, bool isFocused)
        {
            if (list == null) return;
    
            var dialog = list.serializedProperty.GetArrayElementAtIndex(index);
    
            var position = new Rect(rect);
    
            var foldout = dialog.FindPropertyRelative("Foldout");
            var name = dialog.FindPropertyRelative("Name");
    
            {
                // make the label be a foldout
                foldout.boolValue = EditorGUI.Foldout(new Rect(position.x, position.y, 10, EditorGUIUtility.singleLineHeight), foldout.boolValue, foldout.boolValue ? "" : name.stringValue);
    
                var sentencesListKey = dialog.propertyPath;
                var sentences = dialog.FindPropertyRelative("Sentences");
    
                if (foldout.boolValue)
                {
                    // draw the name field
                    name.stringValue = EditorGUI.TextField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), name.stringValue);
                    position.y += EditorGUIUtility.singleLineHeight;
    
                    if (!_sentencesListDict.ContainsKey(sentencesListKey))
                    {
                        // create reorderabl list and store it in dict
                        var sentencesList = new ReorderableList(sentences.serializedObject, sentences)
                        {
                            displayAdd = true,
                            displayRemove = true,
                            draggable = true,
    
                            // header for the dialog list
                            drawHeaderCallback = DrawSentencesHeader,
    
                            // how a sentence is displayed
                            drawElementCallback = (sentenceRect, sentenceIndex, sentenceIsActive, sentenceIsFocused) =>
                            {
                                var sentence = sentences.GetArrayElementAtIndex(sentenceIndex);
    
                                // draw simple textArea for sentence
                                sentence.stringValue = EditorGUI.TextArea(sentenceRect, sentence.stringValue);
                            },
    
                            // Sentences have simply a fixed height of 2 lines
                            elementHeight = EditorGUIUtility.singleLineHeight * 2,
    
                            // when a sentence is added
                            onAddCallback = (sentList) =>
                            {
                                sentList.serializedProperty.arraySize++;
                                var addedElement = sentList.serializedProperty.GetArrayElementAtIndex(sentList.serializedProperty.arraySize - 1);      
    
                                addedElement.stringValue = "";
                            }
                        };
    
                        // store the created ReorderableList
                        _sentencesListDict[sentencesListKey] = sentencesList;
                    }
    
                    // Draw the list
                    _sentencesListDict[sentencesListKey].DoList(new Rect(position.x, position.y, position.width, position.height - EditorGUIUtility.singleLineHeight));
                }
            }
        }
    
        #endregion Elements
    
        #endregion Drawers
    
    
        #region Helpers
    
        #region HeightGetter
    
        /// <summary>
        /// Returns the height of given Conversation property
        /// </summary>
        /// <param name="conversation"></param>
        /// <returns>height of given Conversation property</returns>
        private float GetConversationHeight(SerializedProperty conversation)
        {
            var foldout = conversation.FindPropertyRelative("Foldout");
    
            // if not foldout the height is simply 1 line
            var height = EditorGUIUtility.singleLineHeight;
    
            // otherwise we sum up every controls and child heights
            if (foldout.boolValue)
            {
                // we need some more lines:
                //  for the Name field,
                // the list header,
                // the list buttons and a bit buffer
                height += EditorGUIUtility.singleLineHeight * 5;
    
    
                var dialogues = conversation.FindPropertyRelative("Dialogues");
    
                for (var d = 0; d < dialogues.arraySize; d++)
                {
                    var dialog = dialogues.GetArrayElementAtIndex(d);
                    height += GetDialogueHeight(dialog);
                }
            }
    
            return height;
        }
    
        /// <summary>
        /// Returns the height of given Dialogue property
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns>height of given Dialogue property</returns>
        private float GetDialogueHeight(SerializedProperty dialog)
        {
            var foldout = dialog.FindPropertyRelative("Foldout");
    
            // same game for the dialog if not foldout it is only a single line
            var height = EditorGUIUtility.singleLineHeight;
    
            // otherwise sum up controls and child heights
            if (foldout.boolValue)
            {
                // we need some more lines:
                //  for the Name field,
                // the list header,
                // the list buttons and a bit buffer
                height += EditorGUIUtility.singleLineHeight * 4;
    
                var sentences = dialog.FindPropertyRelative("Sentences");
    
                // the sentences are easier since they always have the same height
                // in this example 2 lines so simply do
                // at least have space for 1 sentences even if there is none
                height += EditorGUIUtility.singleLineHeight * Mathf.Max(1, sentences.arraySize) * 2;
            }
    
            return height;
        }
    
        #endregion
    
        #endregion Helpers
    }
    
