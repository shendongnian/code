    clsStudent selectedStudent = students.FirstOrDefault(x => x.NAME == name);
    if (selectedStudent != null)
    {
        txtbox2.Text = selectedStudent.COURSE;
        txtbox3.Text = selectedStudent.STUDENTCLASS;
        txtbox4.Text = selectedStudent.Gpa.ToString();
    }
    else
    {
        MessageBox.Show("Name does not exist");
    }
