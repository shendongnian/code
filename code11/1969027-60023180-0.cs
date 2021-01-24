        public void LoginTeacher()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection("your connection string"))
            using (SqlCommand cmd = new SqlCommand("TeacherLogin", cn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username",SqlDbType.VarChar,100 ).Value = Txt_User.Text;
                cmd.Parameters.Add("@password",SqlDbType.VarChar, 100 ).Value =Txt_Pass.Text;
                cn.Open();
                dt.Load(cmd.ExecuteReader());
            } //Your connection and command are both disposed
            if (dt.Rows.Count > 0)
            {
                TeacherDash teacherDash = new TeacherDash();
                teacherDash.lblusertype.Text = $"{dt.Rows[0][1]} {dt.Rows[0][2]}";
                teacherDash.ShowDialog();
                Close();
            }
            else
                MessageBox.Show("Sorry, login failed");
        }
