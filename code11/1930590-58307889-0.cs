    public class Item : MonoBehaviour
    {
        [HideInInspector]
        public Section Section;
        [HideInInspector]
        public System.Enum Value;
        [HideInInspector]
        public SectionA a;
        [HideInInspector]
        public SectionB b;
    }
 
    switch (item.Section)
    {
        case Section.A:
            item.Value = EditorGUILayout.EnumPopup(item.a = (SectionA)(item.Value ?? item.a));
            break;
        case Section.B:
            item.Value = EditorGUILayout.EnumPopup(item.b = (SectionB)(item.Value ?? item.b));
            break;
    }
