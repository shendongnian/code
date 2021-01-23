    private void LoadGradeInstances()
    {
        GradeInstanceRepository repo = new GradeInstanceRepository();
        int gradeId = 5; //For example.
        cmbGradeInstance.DataSource = repo.FindAll().Where(g => g.GradeId == gradeID && g.Year.Date == currentYear);
    }
