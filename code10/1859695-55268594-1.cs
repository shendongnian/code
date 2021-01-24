    // Disable the Button
    EditorGUI.BeginDisabledGroup(myScript.objectsinfo.Length == 0);
    {
        // change fontColor
        var originalFontColor = GUI.contentColor;
        if(myScript.objectsinfo.Length == 0) GUI.contentColor = Color.Red;
        {
            // Change the text
            if (GUILayout.Button(myScript.objectsinfo.Length == 0 ? "No Results" :"Search"))
            {
                    myScript.Search();
            }
        }
        // reset back to normal color
        GUI.contentColor = originalFontColor;
    }
    EditorGUI.EndDisabledGroup();
