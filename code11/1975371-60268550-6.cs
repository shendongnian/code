    public class ShortKeyDialog : EditorWindow
    {
        private ShortCut keys;
        private ShortCut newKeys;
        private Action<ShortCut> callback;
        private bool changed;
    
        public static void ShowDialog( ShortCut currentShortcut, Action<ShortCut> onDone)
        {
            var dialog = GetWindow<ShortKeyDialog>();
            dialog.keys = currentShortcut;
            dialog.newKeys = currentShortcut;
            dialog.callback = onDone;
            dialog.minSize = new Vector2(300, 200);
            dialog.position = new Rect(Screen.width / 2f + 150, Screen.height / 2f + 100, 300, 200);
            dialog.ShowModalUtility();
        }
    
        private void OnGUI()
        {
            //Get pressed keys
            var e = Event.current;
            if (e?.isKey == true)
            {
                switch (e.type)
                {
                    case EventType.KeyDown:
                        switch (e.keyCode)
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
                            case KeyCode.Period:
                                // etc depends on your needs I guess
                                changed = true;
                                newKeys = new ShortCut (e.keyCode, e.control, e.alt, e.shift);
    
                                // Refresh the EditorWindow
                                Repaint();
                                break;
                        }
                        break;
                }
    
                // Use all key presses so nothing else handles them 
                // e.g. also not the Unity editor itself like e.g. for CTRL + S
                e.Use();
            }
    
            EditorGUILayout.LabelField("Current Shortcut");
            EditorGUILayout.HelpBox(keys.ToString(), MessageType.None);
    
            EditorGUILayout.Space();
    
            EditorGUILayout.LabelField("Press buttons to assign a new shortcut", EditorStyles.textArea);
    
            EditorGUILayout.HelpBox(newKeys.ToString(), MessageType.None);
    
            EditorGUILayout.Space();
    
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Cancel"))
                {
                    Close();
                }
                EditorGUI.BeginDisabledGroup(!changed);
                {
                    if (GUILayout.Button("Save"))
                    {
                        callback?.Invoke(newKeys);
                        Close();
                    }
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
