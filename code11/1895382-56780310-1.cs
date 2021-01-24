        [Serializable]
        public struct WeaponTextureMaps
        {
            public Material material;
            public Texture normalMap;
            public Texture albedoMap;
            public Texture metalicMap;
            public Texture ambientOcullsionMap;
            public bool hasEmission;
     
            public Texture emissionMap;
        }
    #if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(WeaponTextureMaps))]
        public class WeaponTextureMapsDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                var material = property.FindPropertyRelative("material");
                var normalMap = property.FindPropertyRelative("normalMap");
                var albedoMap = property.FindPropertyRelative("albedoMap");
                var metalicMap = property.FindPropertyRelative("metalicMap");
                var ambientOcullsionMap = property.FindPropertyRelative("ambientOcullsionMap");
                var hasEmission = property.FindPropertyRelative("hasEmission");
        
                var emissionMap = property.FindPropertyRelative("emissionMap");
        
                // Using BeginProperty / EndProperty on the parent property means that
                // prefab override logic works on the entire property.
                EditorGUI.BeginProperty(position, label, property);
        
                // Draw label
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), material);
                position.y += EditorGUIUtility.singleLineHeight;
        
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), normalMap);
                position.y += EditorGUIUtility.singleLineHeight;
        
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), albedoMap);
                position.y += EditorGUIUtility.singleLineHeight;
        
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), metalicMap);
                position.y += EditorGUIUtility.singleLineHeight;
        
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), ambientOcullsionMap);
                position.y += EditorGUIUtility.singleLineHeight;
        
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), hasEmission);
                position.y += EditorGUIUtility.singleLineHeight;
        
                if (hasEmission.boolValue)
                {
                    EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), emissionMap);
                }
        
                EditorGUI.EndProperty();
            }
        
            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                var hasEmission = property.FindPropertyRelative("hasEmission");
        
                return EditorGUIUtility.singleLineHeight * (hasEmission.boolValue ? 8 : 7);
            }
        }
    #endif
    
