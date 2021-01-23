    DataSet studentsList = students.GetAllStudents();
    bool empty = IsEmpty(studentsList); // check DataSet here, see the link above
    if(empty)
    {
        GridView1.Visible = false;
    }
    else
    {
        GridView1.DataSource = studentsList;
        GridView1.DataBind();
    }
