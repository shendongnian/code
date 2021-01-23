    public void PrepareSubjectCombo()
    {
        // Grab a list of subjects for the dialog box
        IRepository<Subject> subjectRepository = new Repository<Subject>();
        List<Subject> subjects = subjectRepository.GetAll().OrderBy(t => t.Position).ToList();
        ViewData["Subjects"] = subjects;
    }
