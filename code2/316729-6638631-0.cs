    public void PrepareSubjectCombo()
    {
        // Grab a list of subjects for the dialog box
        IRepository<Subject> subjectRepository = new Repository<Subject>();
        List<Subject> subjects = subjectRepository.GetAll().OrderBy(t => t.Position).ToList();
        subjects.Insert(0, new Subject() { ID = 0, Name = "- Please Select -" });
        // Add this line
        // Make sure you use the correct ID for the "Other" subject
        subjects.Add(new Subject() { ID = 100, Name = "Other" });
        // If you determine the ID based on the list, simply set the ID = subjects.Count + 1
        int otherID = subjects.Count + 1;
        subjects.Add(new Subject() { ID = otherID, Name = "Other" });
        ViewData["Subjects"] = subjects;
    }
