    public string Subject { 
        get { 
            return SubjectID == null ? null : SubjectReference.GetSubject(SubjectID);
        }
    }
