    #if UNITY_EDITOR
        using UnityEditor;
    #endif
    
    public class Character : Scriptable Object
    {
        ...
    }
    
    #if UNITY_EDITOR
    
    [CustomEditor(typeof(Character))]
    public class CharacterEditor : Editor
    {
        private SerializedProperty firstName;
        private SerializedProperty middleName;
        private SerializedProperty lastName;
        private SerializedProperty fullName;
        private void OnEnable()
        {
            firstName = serializedObject.FindProperty("firstName");
            middleName= serializedObject.FindProperty("middleName");
            lastName= serializedObject.FindProperty("lastName");
            fullName= serializedObject.FindProperty("fullName");
        }
        public override void OnInspectorGUI()
        {
            // draw the default inspector
            base.OnInspectorGUI();
            serializedObject.Update();
            fullName.stringValue = string.Format("{0} {1} {2}", firstName, middleName, lastName);
            serializedObject.ApplyModifiedProperties();
        }
    }
    
    #endif
