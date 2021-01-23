    private void LoadStudentGrades(int gradeParaleloId, int subjectId)
    {
        GradeStudentRepository gradeStudentRepo = new GradeStudentRepository();
        students = gradeStudentRepo.FindAllGradeStudents().Where(g => g.GradeParaleloId == gradeParaleloId).Select(g => g.Student);
        int i = 1;
        foreach (var student in students)
        {
            dataGridView1.Rows.Add(i.ToString(), student.LastNameFather + " " + student.LastNameMother + ", " + student.Name);
            i++;
        }
    }
