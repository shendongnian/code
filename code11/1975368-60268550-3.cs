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
                            
                            switch(e.keyCode)
                            {
                                // Here you will need all allowed keycodes
                                case KeyCode.A:
                                case KeyCode.B:
                                case KeyCode.C:
                                case KeyCode.D:
                                case KeyCode.E:
                                case KeyCode.F:
                                case KeyCode.G:
                                case KeyCode.H:
                                case KeyCode.I:
                                case KeyCode.J:
                                case KeyCode.K:
                                case KeyCode.L:
                                case KeyCode.M:
                                case KeyCode.N:
                                case KeyCode.O:
                                case KeyCode.P:
                                case KeyCode.Q:
                                case KeyCode.R:
                                case KeyCode.S:
                                case KeyCode.T:
                                case KeyCode.U:
                                case KeyCode.V:
                                case KeyCode.W:
                                case KeyCode.X:
                                case KeyCode.Y:
                                case KeyCode.Z:
                                case KeyCode.F1:
                                case KeyCode.F2:
                                case KeyCode.F3:
                                case KeyCode.F4:
                                case KeyCode.F5:
                                case KeyCode.F6:
                                case KeyCode.F7:
                                case KeyCode.F8:
                                case KeyCode.F9:
                                case KeyCode.F10:
                                case KeyCode.F11:
                                case KeyCode.F12:
                                case KeyCode.F13:
                                case KeyCode.F14:
                                case KeyCode.F15:
                                case KeyCode.Comma:
                                case KeyCode.Plus:
                                case KeyCode.Minus:
                                // etc depends on your needs I guess
                                    changed = true;
                                    newKeys = new Shortcut(){Shift = e.shift, Ctrl = e.control, Alt = e.alt, Key = e.keyCode};
                                    break;
                                
                            }
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
