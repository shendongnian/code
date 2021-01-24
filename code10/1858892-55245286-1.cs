    // only show the button while the list is empty
    if(gameobjecttest.Count == 0)
    {
        if (GUILayout.Button("Search"))
        {
             ...
        }
    
        // skip the rest
        return;
    }
    // otherwise show the list
    EditorGUILayout.BeginHorizontal();
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(300), GUILayout.Height(400));
        {
            foreach (GameObject go in gameobjecttest)
            {
                EditorGUILayout.LabelField(go.name);
            }
        }
        EditorGUILayout.EndScrollView();
    }
    EditorGUILayout.EndHorizontal();
    
