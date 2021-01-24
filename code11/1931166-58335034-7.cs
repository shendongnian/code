    #if UNITY_EDITOR
        private SubjectSO _previousSubjectSO;
    
        private void Update()
        {
            if(_previousSubjectSO != _currentSubjectSO)
            {
                HandleSubjectChange(_previousSubjectSO, _currentSubjectSO);
                _previousSubjectSO = _currentSubjectSO;
            }
        }
    #endif
