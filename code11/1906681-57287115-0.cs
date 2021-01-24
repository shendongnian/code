    <!-- language-all: lang-c# -->    
        #if UNITY_EDITOR // exclude this from a build
        using Unity.Editor;
        #endif
        [Flags]
        public enum DoorType
        {
            Top = 0x01,
            Right = 0x02,
            Bottom = 0x04,
            Left = 0x08
        }
        
        public class EnumFlagsAttribute : PropertyAttribute
        {
            public EnumFlagsAttribute() { }
        }
        
        #if UNITY_EDITOR // exclude this from a build
        [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
        public class EnumFlagsAttributeDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
            {
                _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
            }
        }
        #endif
        
    this allows you to choose one or multiple values from the flag via the Inspector.
    [![enter image description here][1]][1]
    
