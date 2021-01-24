    [CustomEditor(typeof(DoorsLockManager))]
    public class DoorsLockManagerEditor : Editor
    {
        private SerializedProperty _doors;
    
        private void OnEnable()
        {
            _doors = serializedObject.FindProperty("Doors");
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
    
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
    
                // If it's public no worry anyway
                // If it's private still works since we made it a SerializeField
                // However FindPropertyRelative seems to only work for non-MonoBehaviour classes
                // so we have to use this hack around
                var serializedDoor = new SerializedObject(door.objectReferenceValue);
                var lockState = serializedDoor.FindProperty("doorLockState");
    
                // Fetch current values into the serialized "copy"
                serializedDoor.Update();
    
                if (lockState == null)
                {
                    EditorGUILayout.HelpBox("There was an error in the editor script!\nPlease check the log", MessageType.Error);
                    Debug.LogError("Couldn't get lockState property", target);
                    return;
                }
    
                // for the PropertyField there is 
                // no return value since it automatically uses
                // the correct drawer for the according property
                // and directly changes it's value
                EditorGUILayout.PropertyField(lockState, new GUIContent("Door " + i + " Lockstate"));
    
                // or alternatively
                //lockState.boolValue = EditorGUILayout.Toggle("Door " + i + " Lockstate", lockState.boolValue);
    
                // Write back changes, mark as dirty if changed
                // and add a Undo history entry
                serializedDoor.ApplyModifiedProperties();
            }
        }
    }
