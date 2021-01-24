    #if UNITY_EDITOR
        private SubjectSO _previousSubjectSO;
    
        // called when the component is created or changed via the Inspector
        private void OnValidate()
        {
            if(!Apllication.isPlaying) return;
    
            if(_previousSubjectSO != _currentSubjectSO)
            {
                HandleSubjectChange(_previousSubjectSO, _currentSubjectSO);
                _previousSubjectSO = _currentSubjectSO;
            }
        }
    #endif
        
