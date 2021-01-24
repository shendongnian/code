    private void OnGUI()
    {
        var graphPosition = new Rect(0f, 0f, position.width, position.height);
        // UnityEditor.Graphs does not exist for me
        //GraphBackground.DrawGraphBackground(graphPosition, graphPosition);
        var selected = 0;
        var options = new string[]
        {
     "Option1", "Option2", "Option3",
        };
        selected = EditorGUILayout.Popup("Label", selected, options);
        if (windowsToAttach.Count == 2)
        {
            attachedWindows.Add(windowsToAttach[0]);
            attachedWindows.Add(windowsToAttach[1]);
            windowsToAttach = new List<int>();
        }
        BeginWindows();
        if (GUILayout.Button("Create Node"))
        {
            windows.Add(new Rect(10, 10, 200, 40));
        }
        for (var i = 0; i < windows.Count; i++)
        {
            windows[i] = GUI.Window(i, windows[i], DrawNodeWindow, "Window " + i);
        }
        EndWindows();
        if (attachedWindows.Count >= 2)
        {
            for (var i = 0; i < attachedWindows.Count; i += 2)
            {
                DrawNodeCurve(windows[attachedWindows[i]], windows[attachedWindows[i + 1]]);
            }
        }
    }
    
