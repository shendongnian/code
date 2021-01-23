    void Number()
        {
            con.Open();
            int id;
            cmd = new OleDbCommand("select max(ID) from Entry", con);
            string value = (cmd.ExecuteScalar().ToString());
            string max;
            if (value != null)
            {
              
                    max = "0"+value;
                    id = Convert.ToInt32(max);
                    lblNumber.Text = "Acronym of Reg form like for Emp for Employee" + Convert.ToString((id + 1));
                
            }
            con.Close();
        }
