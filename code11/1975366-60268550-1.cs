    public Shortcut someShortCut;
    private void Update()
    {
        if(someShortCut.IsDown())
        {
            Debug.Log("Hello!");
        }
    }
    
    public ShortKeyDialog : EditorWindow
    {
        private ShortCut keys;
        private ShortCut newKeys;
        private Action<ShortCut callback;
        private bool changed;
    
        public static void ShowDialog(ShortCut currentShortcut, Action<ShortCut> onDone)
        {
            var dialog = GetWindow<ShortKeyDialog>();
            dialog.keys = currentShortcut;
            dialog.newKeys = currentShortcut;
    
            dialog.minSize = new Vector2(300,200);
            dialog.position = new Rect(Screen.width / 2f + 150, Screen.height / 2f + 100, 300, 200);
            dialog.ShowModalUtility();
        }
    
        private void OnGUI()
        {
            //Get pressed keys
            var e = Event.current;
            if(e != null)
            {
                if(e.isKey)
                {
                    switch(e.type)
                    {
                        case EventType.KeyDown:
                            
                            break;
                    }
                }
            }
    
            EditorGUILayout.LabelField("Press buttons to assign new shortcut", EditorStyles.textAre);
    
            var builder = new StringBuilder();
            if(newKeys.Ctrl) builder.Append("CTRL + ");
            if(newKeys.Alt) builder.Append("ALT + ");
            if(newKeys.Shift) builder.Append("SHIFT + ");
    
            builder.Append(newKeys.Key.ToString());
    
            var currentText = builder.ToString();
    
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField(currentText);
            EditorGUI.EndDisabledGroup();
    
            EditorGUILayout.BeginHorizontal();
            {
                if(GUILayout.Button("Cancel"))
                {
                    Close();
                }
                EditorGUI.BeginDisabledGroup(!changed);
    
                if(GUILayout.Button("Save"))
                {
                    onDone?.Invoke(newKeys);
                    Close();
                }
    
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
