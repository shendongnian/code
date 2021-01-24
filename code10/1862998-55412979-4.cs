    [CustomEditor(typeof(DialogueTrigger))]
    public class DialogueTriggerEditor : Editor
    {
        private SerializedProperty _dialogues;
    
        // store which dialogue is foldout
        private List<bool> dialogueFoldout = new List<bool>();
    
        private void OnEnable()
        {
            _dialogues = serializedObject.FindProperty("dialogue");
    
            for (var i = 0; i < _dialogues.arraySize; i++)
            {
                dialogueFoldout.Add(false);
            }
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
    
            serializedObject.Update();
    
            for (var i = 0; i < _dialogues.arraySize; i++)
            {
                var dialogue = _dialogues.GetArrayElementAtIndex(i);
    
                dialogueFoldout[i] = EditorGUILayout.Foldout(dialogueFoldout[i], "Dialogue " + i);
    
                // make the next fields look nested below the before one
                EditorGUI.indentLevel++;
    
                if (dialogueFoldout[i])
                {
                    var name = dialogue.FindPropertyRelative("name");
                    var sentences = dialogue.FindPropertyRelative("sentences");
    
                    EditorGUILayout.PropertyField(name);
    
                    // if you still want to be able to controll the size
                    sentences.arraySize = EditorGUILayout.IntField("Senteces size", sentences.arraySize);
    
                    // make the next fields look nested below the before one
                    EditorGUI.indentLevel++;
                    for (var s = 0; s < sentences.arraySize; s++)
                    {
                        EditorGUILayout.PropertyField(sentences.GetArrayElementAtIndex(s), new GUIContent("Sentece " + s));
                    }
                    EditorGUI.indentLevel--;
                }
    
                EditorGUI.indentLevel--;
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    }
