    [SerializedField] private SubjectSO _currentSubjectSO;
    public SubjectSO subjectSO
    {
        get { return _currentSubjectSO; }
        set 
        {
            HandleSubjectChange(value);
        }
    }
    
    private void HandleSubjectChange(SubjectSO newSubject)
    {
        // If not null unsubscribe from the current subject
        if(subject) subjectSO.OnTrigger -= this.OnTriggerCallback;
        // make the change
        _currentSubjectSO = newSubject;
        // If not null subscribe to the new subject
        if(subject) subjectSO.OnTrigger += this.OnTriggerCallback;
    }
        
