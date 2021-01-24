    using UnityEditor;
    using UnityEditorInternal;
    [CustomEditor(typeof(test))]
    public class testEditor : Editor
    {
        private SerializedProperty Data;
        private ReorderableList dataList;
    
        public void OnEnable()
        {
            Data = serializedObject.FindProperty(nameof(test.Data));
    
            //                                 should the list
            //                                                     | be reorderable by drag&drop of the entries?
            //                                                     |     | display a header for the list?
            //                                                     |     |     | have an Add button?
            //                                                     |     |     |     | have a Remove button?
            //                                                     v     v     v     v
            dataList = new ReorderableList(serializedObject, Data, true, true, true, true)
            {
                // what shall be displayed as header
                drawHeaderCallback = rect => EditorGUI.LabelField(rect, Data.displayName),
    
                elementHeightCallback = index =>
                {
                    var element = Data.GetArrayElementAtIndex(index);
                    var elementList = element.FindPropertyRelative(nameof(data.list));
                    return EditorGUIUtility.singleLineHeight * (elementList.isExpanded ? elementList.arraySize + 4 : 3);
                },
    
                drawElementCallback = (rect, index, isFocused, isActive) =>
                {
                    var element = Data.GetArrayElementAtIndex(index);
    
                    EditorGUI.LabelField(new Rect(rect.x,rect.y,rect.width,EditorGUIUtility.singleLineHeight), element.displayName);
                    // in order to print the list in the next line
                    rect.y += EditorGUIUtility.singleLineHeight;
    
                    var elementList = element.FindPropertyRelative(nameof(data.list));
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width,  EditorGUIUtility.singleLineHeight * (elementList.isExpanded ? elementList.arraySize + 1 : 1)), elementList, true);
                }
            };
        }
    
        public override void OnInspectorGUI()
        {
            // load all current values of the properties in test into the SerializedProperty "clones"
            serializedObject.Update();
    
            dataList.DoLayoutList();
    
            // write back the values of the SerializedProperty "clones" into the real properties of test
            serializedObject.ApplyModifiedProperties();
        }
    }
