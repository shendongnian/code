    // Make it private so no other script can directly change this
    [SerializedField] private SubjectSO _currentSubjectSO;
    // The value can only be changed using this property
    // automatically calling HandleSubjectChange
    public SubjectSO subjectSO
    {
        get { return _currentSubjectSO; }
        set 
        {
            HandleSubjectChange(this._currentSubjectSO, value);
        }
    }
    
    private void HandleSubjectChange(SubjectSO oldSubject, SubjectSO newSubject)
    {
        if (!this.isActiveAndEnabled) return;
        // If not null unsubscribe from the current subject
        if(oldSubject) oldSubject.OnTrigger -= this.OnTriggerCallback;
        // If not null subscribe to the new subject
        if(newSubject) 
        {
            newSubject.OnTrigger -= this.OnTriggerCallback;
            newSubject.OnTrigger += this.OnTriggerCallback;
        }
         // make the change
        _currentSubjectSO = newSubject;
    }
        
