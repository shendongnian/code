    EditorGUI.BeginDisabledGroup(gameobjecttest.Count != 0);
    {
        if (GUILayout.Button("Search"))
        {
             ...
        }
    }
    EditorGUI.EndDisabledGroup();
