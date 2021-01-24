    [CustomEditor(typeof(test))]
    public class testEditor : Editor
    {
        private SerializedProperty Data;
    
        public void OnEnable()
        {
            Data = serializedObject.FindProperty(nameof(test.Data));
        }
    
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
    
            // load all current values of the properties in test into the SerializedProperty "clones"
            serializedObject.Update();
    
            if (GUILayout.Button("Add"))
            {
                // this simply adds a new entry to the list
                // since the data and list are both serializable this already initializes them with values
                Data.arraySize++;
    
    
                // Actually the entire following block is redundant 
                // by using Data.arraySize++; the new added entry automatically 
                // is a full copy of the entry before!
                // I just decided to add it as example how you would access further nested SerializedProperties
    
                //// if there was an element before now there are two
                //if (Data.arraySize >= 2)
                //{
                //    // get the last added element
                //    var lastElement = Data.GetArrayElementAtIndex(Data.arraySize - 1);
                //    var beforeElement = Data.GetArrayElementAtIndex(Data.arraySize - 2);
    
                //    // deep clone the list
                //    var lastElementList = lastElement.FindPropertyRelative(nameof(data.list));
                //    var beforeElementList = beforeElement.FindPropertyRelative(nameof(data.list));
    
                //    lastElementList.arraySize = beforeElementList.arraySize;
                //    for (var i = 0; i < lastElementList.arraySize; i++)
                //    {
                //        lastElementList.GetArrayElementAtIndex(i).intValue = beforeElementList.GetArrayElementAtIndex(i).intValue;
                //    }
                //}
            }
    
            if (GUILayout.Button("Clear"))
            {
                Data.arraySize = 0;
            }
    
            // write back the values of the SerializedProperty "clones" into the real properties of test
            serializedObject.ApplyModifiedProperties();
        }
    }
