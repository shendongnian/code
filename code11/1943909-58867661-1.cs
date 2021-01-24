    using UnityEditor;
    using UnityEngine;
    
    [CustomPropertyDrawer(typeof(CustomAction))]
    internal sealed class CustomActionPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.serializedObject.Update();
    
            var height = EditorGUIUtility.singleLineHeight;
    
            position.height = height;
    
            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, new GUIContent(property.displayName));
    
            position.y += height;
    
            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
    
                var button = property.FindPropertyRelative(nameof(CustomAction.Button));
                EditorGUI.PropertyField(position, button);
                position.y += height;
    
                var scene1 = property.FindPropertyRelative(nameof(CustomAction.Scene1));
                DrawScenePicker(position, scene1);
                position.y += height;
    
                var scene2 = property.FindPropertyRelative(nameof(CustomAction.Scene2));
                DrawScenePicker(position, scene2);
                position.y += height;
    
                EditorGUI.indentLevel--;
            }
    
            property.serializedObject.ApplyModifiedProperties();
        }
    
        private void DrawScenePicker(Rect position, SerializedProperty property)
        {
            using (var scope = new EditorGUI.ChangeCheckScope())
            {
                var label = EditorGUI.BeginProperty(position, null, property);
                var value = AssetDatabase.LoadAssetAtPath<SceneAsset>(property.stringValue);
                var field = EditorGUI.ObjectField(position, label, value, typeof(SceneAsset), false);
    
                if (!scope.changed)
                    return;
    
                var asset = field as SceneAsset;
    
                property.stringValue = asset != null ? AssetDatabase.GetAssetPath(asset) : null;
            }
        }
    
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = EditorGUIUtility.singleLineHeight;
    
            if (property.isExpanded)
                height *= 4;
    
            return height;
        }
    }
