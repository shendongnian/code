        private void Update()
        {
            if(_previousSubjectSO != subjectSO)
            {
                HandleSubjectChange(subjectSO);
            }
        }
        
