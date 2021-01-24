    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        if (picked)
        {
            for (var i = 0; i < pickeditems.Count; i++)
            {
                // NOTE: Never mix serializedProperties and direct access/modifications on the target!
                // This messes up the marking dirty and saving these changes!
                // Rather always go through the SerializedProperties so the editor handles everything automatically
                _serializedpickeditems.arraySize++;
                _serializedpickeditems.GetArrayElementAtIndex(i).objectReferenceValue = pickeditems[i];
            }
            picked = false;
            pickeditems.Clear();
        }
        for (var i = 0; i < _serializedpickeditems.arraySize; i++)
        {
            var item = _serializedpickeditems.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(item, new GUIContent("Picked Item " + i + " " + (item.objectReferenceValue ? item.objectReferenceValue.name : "null")));
     
            // The only case you would need to go deeper here and use 
            // your new SerializedObject would be if you actually make changes
            // to these objects/components like e.g. directly allow to edit their name
        }
        serializedObject.ApplyModifiedProperties();
    }
    
