    [CustomPropertyDrawer(typeof(SelectionAttribute))]
    public class SelectionAttributDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // The 6 comes from extra spacing between the fields (2px each)
            return EditorGUIUtility.singleLineHeight;
        }
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
    
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "Only works with string", MessageType.Error);
                return;
            }
    
            //TODO: somewhere you have to get the options from
            var options = new[] { "A", "B", "C", "D", "E" };
    
            if (options == null || options.Length < 1)
            {
                EditorGUI.HelpBox(position, "No options available", MessageType.Error);
                return;
            }
    
            var selectionAttribute = (SelectionAttribute)attribute;
    
            EditorGUI.BeginProperty(position, label, property);
    
            EditorGUI.BeginChangeCheck();
            selectionAttribute.Index = EditorGUI.Popup(position, options.ToList().IndexOf(property.stringValue), options);
            if (EditorGUI.EndChangeCheck())
            {
                property.stringValue = options[selectionAttribute.Index];
            }
    
            EditorGUI.EndProperty();
        }
    }
    
