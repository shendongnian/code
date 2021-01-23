    listBox1.Items.Clear();
    listBox1.Text = "";
    econ = new SqlConnection();
    econ.ConnectionString = emp_con;
    econ.Open();
    float iGrade = 0;
    float Grade = 0.00F;
    string Log_User;
    float Count, Score;
    string n = "";
    string strScore = "Score: ";
    string strGrade = "Grade: ";
    string strCount = "Count: ";
    string date = DateTime.Now.ToShortTimeString();
    ecmd = new SqlCommand("SELECT Log_User, Count = COUNT(Det_Score), Score = SUM(Det_Score) FROM MEMBER M,DETAILS D WHERE D.Emp_Id = M.Emp_Id AND Log_User like" + "'" + Convert.ToString(comEmployee.Text) + "'AND Month(Sched_Start) =" + "'" + Convert.ToInt32(iMonth) + "'AND Year(Sched_Start) =" + "'" + Convert.ToInt32(txtYear.Text) + "'GROUP BY Log_User", econ);
    ecmd.CommandType = CommandType.Text;
    ecmd.Connection = econ;
    dr = ecmd.ExecuteReader();
    listBox1.Items.Add("As of " + date + ": "+ comMonth.Text + ", "+ txtYear.Text);
    while (dr.Read())
    {
       if (dr == null || !dr.HasRows)
       {
          MessageBox.Show("No record found.", "Error");
       }
       else
       {
          Log_User = (string)dr["Log_User"];
          Count = (dr["Count"] as int?) ?? 0;
          Score = (dr["Score"] as int?) ?? 0;
          try
          {
             iGrade = Score / Count;
             Grade = iGrade * 100;
          }
          catch (DivideByZeroException)
          {
              Console.WriteLine("Exception occured");
          }
          listBox1.Items.Add(Convert.ToString(n));
          listBox1.Items.Add(Convert.ToString(Log_User));
          listBox1.Items.Add(Convert.ToString(strCount + Count));
          listBox1.Items.Add(Convert.ToString(strScore + Score));
          listBox1.Items.Add(Convert.ToString(strGrade + Grade));
          }
       }               
       econ.Close();
