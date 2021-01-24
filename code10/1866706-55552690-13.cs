    private Student _student;
    public editMark(Student student)
    {
        InitializeComponent();
        // Remember the student
        _student = student;
        StartPosition = FormStartPosition.CenterScreen;
        
        txtStudentID.Text = student.Id;
        txtMark.Text = student.Mark;
        txtStudentID.Focus();
    }
