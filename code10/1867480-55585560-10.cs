    using UnityEditor;
    using UnityEngine;
    
    [CustomPropertyDrawer(typeof(EnumFlagAttribute))]
    public class EnumFlagDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
    
            if (property.propertyType == SerializedPropertyType.Enum)
            {
                switch (((EnumFlagAttribute)attribute)._layout)
                {
                    case EnumFlagAttribute.FlagLayout.Dropdown:
                        property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
                        break;
    
                    case EnumFlagAttribute.FlagLayout.List:
                        var buttonsIntValue = 0;
                        var enumLength = property.enumNames.Length;
                        var flagSet = new bool[enumLength];
    
                        EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), label);
                        EditorGUI.indentLevel++;
    
    
                        var posX = position.x;
                        EditorGUI.BeginChangeCheck();
                        {
                            for (var i = 0; i < enumLength; i++)
                            {
                                position.y += EditorGUIUtility.singleLineHeight;
    
                                // Check if the flag is currently set
                                if (((EnumFlagAttribute.FlagLayout)property.intValue).HasFlag((EnumFlagAttribute.FlagLayout)(1 << i)))
                                {
                                    flagSet[i] = true;
                                }
    
                                EditorGUI.PrefixLabel(new Rect(posX, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), new GUIContent(property.enumNames[i]));
    
                                var toogePosition = new Rect(posX + EditorGUIUtility.labelWidth, position.y, EditorGUIUtility.currentViewWidth - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);
                                flagSet[i] = GUI.Toggle(toogePosition, flagSet[i], property.enumNames[i]);
    
    
                                if (flagSet[i])
                                {
                                    buttonsIntValue += 1 << i;
                                }
                            }
                        }
                        if (EditorGUI.EndChangeCheck())
                        {
                            property.intValue = buttonsIntValue;
                        }
    
    
                        EditorGUI.indentLevel--;
    
                        break;
                }
            }
            else
            {
                var color = GUI.color;
                GUI.color = new Color(1f, 0.2f, 0.2f);
                EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height), label);
                position.x += EditorGUIUtility.labelWidth;
                EditorGUI.HelpBox(new Rect(position.x, position.y, position.width - EditorGUIUtility.labelWidth, position.height), "Use [EnumFlags] only with an enum!", MessageType.Error);
                GUI.color = color;
            }
    
            EditorGUI.EndProperty();
        }
    
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (((EnumFlagAttribute)attribute)._layout == EnumFlagAttribute.FlagLayout.Dropdown)
            {
                return EditorGUIUtility.singleLineHeight;
            }
    
    
            return (property.enumNames.Length + 1) * EditorGUIUtility.singleLineHeight;
        }
    }
