    using UnityEditor;
    using UnityEngine;
    [CustomEditor(typeof(uitest))]
    [CanEditMultipleObjects]
    public class uitesteditor : Editor
    {
        static string[] customProperties = new string[] { "test", "Check", "MinValue", "MaxValue", "defaultValue" };
        SerializedProperty test, check, MaxValue, MinValue, defaultValue;
        private void OnEnable()
        {
            test = serializedObject.FindProperty("test");
            check = serializedObject.FindProperty("Check");
            MinValue = serializedObject.FindProperty("MinValue");
            MaxValue = serializedObject.FindProperty("MaxValue");
            defaultValue = serializedObject.FindProperty("defaultValue");
        }
        public override void OnInspectorGUI()
        {
            // Draw common properties (by excluding all custom ones)
            DrawPropertiesExcluding(serializedObject, customProperties);
            EditorGUILayout.PropertyField(test, new GUIContent("test"));
            switch ((uitest.TestType)test.intValue)
            {
                case uitest.TestType.CheckBox:
                    EditorGUILayout.PropertyField(check, new GUIContent("Check"));
                    break;
                case uitest.TestType.Slider:
                    EditorGUILayout.PropertyField(MinValue, new GUIContent("Min value"));
                    EditorGUILayout.PropertyField(MaxValue, new GUIContent("Max value"));
                    EditorGUILayout.PropertyField(defaultValue, new GUIContent("Default value"));
                    break;
            }
            if (GUI.changed) serializedObject.ApplyModifiedProperties();
        }
    }
