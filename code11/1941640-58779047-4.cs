    Student student = dbContext.Students.Find(10);
    // let user change student attributes
    ...
    bool changesAccepted = AskIfChangesOk();
    if (!changesAccepted)
    {    // Refetch the student.
         // can't use Find, because that would give the changed Student
         student = dbContext.Students.Where(s => s.Id == 10).FirstOrDefault();
    }
  
    // now use the refetched Student with the original data
        
