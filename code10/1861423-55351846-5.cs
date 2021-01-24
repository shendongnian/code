    [CustomEditor(typeof(DoorsLockManager))]
    public class DoorsLockManagerEditor : Editor
    {
        SerializedProperty _doors;
    
        void OnEnable ()
        {
            _doors = serializedObject.FindProperty("Doors");
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
    
            // Fetch current values into the serialized "copy"
            serializedObject.Update();
    
            for(int i = 0; i < _doors.arraySize; i++)
            {
                var door = _doors.GetArrayElememtAtIndex(i);
    
                if (door == null || door.objectReference == null)
                    continue;
    
                // Works since we made it a SerializeField even though it's private
                var lockState = door.FindPropertyRelative("doorLockState");
   
                // for the PropertyField there is 
                // no return value since it automatically uses
                // the correct drawer for the according property
                // and directly changes it's value
                EditorGUILayout.PropertyField(lockState, new GUIContent("Door " + i + " Lockstate"));
            }
    
            // Write back changes, mark as dirty if changed
            // and add a Undo history entry
            serialzedObject.ApplyModifiedProperties();
        }
    }
