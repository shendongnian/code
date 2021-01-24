    [CustomEditor(typeof(DoorsLockManager))]
    public class DoorsLockManagerEditor : Editor
    {
        private SerializedProperty _doors;
        private SerializedProperty _globalLockState;
        private bool shouldOverwrite;
    
        private void OnEnable()
        {
            _doors = serializedObject.FindProperty("Doors");
            _globalLockState = serializedObject.FindProperty("_globalLockState");
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            shouldOverwrite = false;
            // Begin a change check here
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_globalLockState);
            if(EditorGUI.EndChangeCheck())
            {
                // overwrite only once if changed
                shouldOverwrite = true;
            }
    
            for (int i = 0; i < _doors.arraySize; i++)
            {
                var door = _doors.GetArrayElementAtIndex(i);
    
                // if door == null the script itself has an error since it can't even find the SerializedProperty
                if (door == null)
                {
                    EditorGUILayout.HelpBox("There was an error in the editor script!\nPlease check the log", MessageType.Error);
                    Debug.LogError("Couldn't get door property", target);
                    return;
                }
    
                if (door.objectReferenceValue == null) continue;
    
                var serializedDoor = new SerializedObject(door.objectReferenceValue);
    
                var lockState = serializedDoor.FindProperty("doorLockState");
    
                serializedDoor.Update();
    
                if (lockState == null)
                {
                    EditorGUILayout.HelpBox("There was an error in the editor script!\nPlease check the log", MessageType.Error);
                    Debug.LogError("Couldn't get lockState property", target);
                    return;
                }
                
                // HERE OVERWRITE
                if(shouldOverwrite)
                {
                    lockState.boolValue = _globalLockState.boolValue;
                }
                else
                {
                    EditorGUILayout.PropertyField(lockState, new GUIContent("Door " + i + " Lockstate"));
                }
    
                serializedDoor.ApplyModifiedProperties();
            }
        }
    }
