    bool isExist = false;
    for (int i = 0; i < students.Length; i++)
    {
        if (name == students[i].NAME)
        {
            txtbox2.Text = students[i].COURSE;
            txtbox3.Text = students[i].STUDENTCLASS;
            txtbox4.Text = students[i].Gpa.ToString();
            isExist = true;
        }
    }
    if (!isExist)
    {
        MessageBox.Show("Name does not exist");
    }
