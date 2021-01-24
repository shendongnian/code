    using UnityEditor;
    using UnityEngine;
    
    [CustomPropertyDrawer(typeof(EnumIntArray), false)]
    public class EnumIntArrayDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
    
            EditorGUI.LabelField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), label);
    
            var values = property.FindPropertyRelative("Values");
            var names = property.FindPropertyRelative("Names");
    
            EditorGUI.indentLevel++;
    
            for (var i = 0; i < values.arraySize; i++)
            {
                var name = names.GetArrayElementAtIndex(i);
                var value = values.GetArrayElementAtIndex(i);
    
                position.y += EditorGUIUtility.singleLineHeight;
    
                var indentedRect = EditorGUI.IndentedRect(position);
    
                EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), name.stringValue);
                value.intValue = EditorGUI.IntField(new Rect(position.x + EditorGUIUtility.labelWidth - indentedRect.x / 2, position.y, EditorGUIUtility.currentViewWidth - EditorGUIUtility.labelWidth - indentedRect.x, EditorGUIUtility.singleLineHeight), value.intValue);
            }
    
            EditorGUI.indentLevel--;
    
            EditorGUI.EndProperty();
        }
    
    
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var values = property.FindPropertyRelative("Values");
    
            return (values.arraySize + 1) * EditorGUIUtility.singleLineHeight;
        }
    }
