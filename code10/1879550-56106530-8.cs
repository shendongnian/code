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
        // called once when the Object of this type gains focus and is shown in the Inspector
        private void OnEnable()
        {
            firstName = serializedObject.FindProperty("firstName");
            middleName= serializedObject.FindProperty("middleName");
            lastName= serializedObject.FindProperty("lastName");
            fullName= serializedObject.FindProperty("fullName");
        }
        // kind of like the Update method of the Inspector
        public override void OnInspectorGUI()
        {
            // draw the default inspector
            base.OnInspectorGUI();
            serializedObject.Update();
            fullName.stringValue = string.Format("{0} {1} {2}", firstName.stringValue, middleName.stringValue, lastName.stringValue);
            serializedObject.ApplyModifiedProperties();
        }
    }
    
    #endif
