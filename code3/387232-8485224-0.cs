    econ = new SqlConnection(); 
    econ.ConnectionString = emp_con; 
    econ.Open(); 
    string Log_User, Count, Score; 
    int iGrade = 0; 
    string n = ""; 
    string strScore = "Score: "; 
    string strGrade = "Grade: "; 
    string strCount = "Count: "; 
    ecmd = new SqlCommand("SELECT Log_User, Count = COUNT(Det_Score), Score = SUM(Det_Score) FROM MEMBER M,DETAILS D WHERE D.Emp_Id = M.Emp_Id AND Month(Sched_Start) like" + "'" + comMonth.Text + "'AND Year(Sched_Start) like" + "'" + txtYear.Text + "'GROUP BY Log_User", econ); 
    ecmd.CommandType = CommandType.Text; 
    ecmd.Connection = econ; 
    dr = ecmd.ExecuteReader(); 
    listBox1.Items.Add(txtYear.Text); 
    listBox1.Items.Add(comMonth.Text); 
    while (dr.Read()) 
    { 
     Log_User = (string)dr["Log_User"]; 
     Count = (string)dr["Count"]; 
     Score = (string)dr["Score"]; 
     iGrade = Convert.ToInt32(Count) / Convert.ToInt32(Score); 
     listBox1.Items.Add(string.Format("{0}", n)); 
     listBox1.Items.Add(string.Format("Grade: {0}", iGrade))); 
     listBox1.Items.Add(string.Format("Score: {0}",  Score))); 
     listBox1.Items.Add(string.Format("Count: {0}", Count)); 
     listBox1.Items.Add(Log_User); 
     listBox1.Items.Add(n.ToString()); 
    } 
 
    econ.Close(); 
    } 
    catch (Exception x) 
    { 
      MessageBox.Show(x.GetBaseException().ToString(), "Connection Status", MessageBoxButtons.OK,     MessageBoxIcon.Error); 
    } 
