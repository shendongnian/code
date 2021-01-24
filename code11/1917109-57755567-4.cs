    using UnityEditor;
    using UnityEngine;
    [CustomEditor(typeof(uitest))]
    [CanEditMultipleObjects]
    public class uitesteditor : Editor
    {
        static string[] customProperties = new string[] { "Check", "MinValue", "MaxValue", "defaultValue" };
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            // Draw common properties (by excluding all custom ones)
            // Could be skipped if there is none such.
            DrawPropertiesExcluding(serializedObject, customProperties);
            var uitarget = target as uitest;
            // Custom UI based on selected enum
            switch (uitarget.test)
            {
                case uitest.TestType.CheckBox:
                    uitarget.Check = EditorGUILayout.Toggle("Check", uitarget.Check);
                    break;
                case uitest.TestType.Slider:
                    uitarget.MinValue = EditorGUILayout.IntField("Min value", uitarget.MinValue);
                    uitarget.MaxValue = EditorGUILayout.IntField("Max value", uitarget.MaxValue);
                    uitarget.defaultValue = EditorGUILayout.IntField("Default value", uitarget.defaultValue);
                    break;
            }
            // Needed only by DrawPropertiesExcluding
            serializedObject.ApplyModifiedProperties();
        }
    }
