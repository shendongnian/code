    #if UNITY_EDITOR
        using UnityEditor;
    #endif
        
        ...
        
        public class ObserverMB : MonoBehaviour
        {
            [SerializeField] private SubjectSO _currentSubjectSO;
            public SubjectSO subjectSO
            {
                get { return _currentSubjectSO; }
                set 
                {
                    HandleSubjectChange(_currentSubjectSO, value);
                }
            }
            
            private void HandleSubjectChange(Subject oldSubject, SubjectSO newSubject)
            {
                // If not null unsubscribe from the current subject
                if(oldSubject) oldSubject.OnTrigger -= this.OnTriggerCallback;
        
                // If not null subscribe to the new subject
                if(newSubject) newSubject.OnTrigger += this.OnTriggerCallback;
        
                // make the change
                _currentSubjectSO = newSubject;
            }
        
            public void OnEnable()
            {
                if(subjectSO) 
                {
                    // I recommend to always use -= before using +=
                    // This is allowed even if the callback wasn't added before
                    // but makes sure it is added only exactly once!
                    subjectSO.OnTrigger -= this.OnTriggerCallback;
                    subjectSO.OnTrigger += this.OnTriggerCallback;
                }
            }
        
            public void OnDisable()
            {
                if(this.subjectSO != null)
                {
                    this.subjectSO.OnTrigger -= this.OnTriggerCallback;
                }
            }
        
            public void OnTriggerCallback(string value)
            {
                Debug.Log("Callback Received! Value = " + value);
            }
        
    #if UNITY_EDITOR
            [CustomEditor(typeof(ObserverMB))]
            private class ObserverMBEditor : Editor 
            { 
                private ObserverMB observerMB;
                private SerializedProperty subject;
        
                private Object currentValue;
        
                private void OnEnable()
                {
                    observerMB = (ObserverMB)target;
                    subject = serializedObject.FindProperty("_currentSubjectSO");
                }
        
                // This is kind of the update method for Inspector scripts
                public override void OnInspectorGUI()
                {
                    // fetches the values from the real target class into the serialized one
                    serializedObject.Update();
        
                    EditorGUI.BeginChangeCheck();
                    {
                        EditorGUILayout.PropertyField(subject);
                    }
                    if(EditorGUI.EndChangeCheck() && EditorApplication.isPlaying)
                    {
                        // compare and eventually call the handle method
                        if(subject.objectReferenceValue != currentValue) observerMB.HandleSubjectChange(currentValue, (SubjectSO)subject.objectReferenceValue);
                    }
                }
            }
    #endif
        }
