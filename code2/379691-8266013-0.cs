    public string Subject { 
        get { 
            if (SubjectID == null) {
                return null;
            }
            return SubjectReference.GetSubject(SubjectID);
        }
    }
