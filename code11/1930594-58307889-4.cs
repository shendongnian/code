    public class Item : MonoBehaviour
    { 
        public Section section;
        public SectionA sectionA;
        public SectionB sectionB;
        public System.Enum Value
        {
            get
            {
                switch(section)
                {
                    case Section.A:
                        return sectionA;
                    case Section.B:
                        return sectionB;
                    default:
                        return null;
                }
            }
        }
    }
    [CustomEditor(typeof(Item))]
    public class ItemEditor : Editor
    {
        SerializedProperty section;
        SerializedProperty sectionA;
        SerializedProperty sectionB;
        void OnEnable()
        {
            section = serializedObject.FindProperty("section");
            sectionA = serializedObject.FindProperty("sectionA");
            sectionB = serializedObject.FindProperty("sectionB");
        }
        public override void OnInspectorGUI()
        {        
            serializedObject.Update();
            EditorGUILayout.PropertyField(section);
            switch ((Section)section.enumValueIndex)
            {
                case Section.A:
                    EditorGUILayout.PropertyField(sectionA);
                    break;
                case Section.B:
                    EditorGUILayout.PropertyField(sectionB);
                    break;
            }   
            serializedObject.ApplyModifiedProperties();
        }
    }
