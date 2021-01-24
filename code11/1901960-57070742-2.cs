    public class YourEditor : Editor
    {
        private SerializedProperty thisImageCaption;
        private SerializedProperty hasAudioClip;
    
        // wherever you get this from
        private XY item;
        private void OnEnable()
        {
            // Link SerializedProperties to the real ones
            thisImageCaption = serializedObject.FindProperty("thisImageCaption");
            hasAudioClip = serializedObject.FindProperty("hasAudioClip");
        }
    
        public override void OnInpectorGUI()
        {
            // Load the current real values
            // into the SerializedProperties
            serializedObject.Update();
    
            // Now only change the SerializedProperties
            thisImageCaption.stringValue = EditorGUILayout.TextArea("Content for the main image slide", thisImageCaption.stringValue);
    
            // Using PropertyField automatically
            // uses the property drawer according
            // to the property's type
            EditorGUILayout.PropertyField(hasAudioClip);
            // now to the tricky part
            // for both slider sub-components you will need
            // to create a serializedObject from the given components e.g.
            var textSerializedObject = new SerializedObject(item.Item2);
            var imageSerializedObject = new SerializedObject(item.Item3);
            // do the update for both
            textSerializedObject.Update();
            imageSerializedObject.Update();
            // now change what you want to change via serializedProperties e.g.
            EditorGUILayout.PropertyField(textSerializedObject.FindProperty("m_text"), new GUIContent("Content for the image cloneslide"));
            EditorGUILayout.PropertyField(imageSerializedObject.FindProperty("m_Sprite"), new GUIContent("This second Image slides image"));
    
            // Write changes back to the real components
            textSerializedObject.ApplyModifiedProperties();
            imageSerializedObject.ApplyModifiedProperties();
            serializedObject.ApplyModifiedProperties();
        }
    }
