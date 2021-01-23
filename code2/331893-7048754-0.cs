     DataSet studentsList = students.GetAllStudents();
      
     if(studentList.Tables[0].Rows.Count > 0) //COUNT DATASET RECORDS
    {
        GridView1.DataSource = studentsList;
        GridView1.DataBind();
    }
    else
    {
       lblError.Text = "NO RECORDS FOUND!";
    }
