      SqlCommand cmdSelect=new SqlCommand("Select file_name, file_content " + 
                  " from Attachments where Email_ID=@ID",this.sqlConnection1);
            cmdSelect.Parameters.Add("@ID",SqlDbType.Int,4);
            cmdSelect.Parameters["@ID"].Value=333;
    
    DataTable dt = new DataTable();
            this.sqlConnection1.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdSelect;
                sda.Fill(dt);
         if(dt.Rows.Count > 0)
    {
            byte[] barrImg=(byte[])dt.Rows[0]["file_content"];
            string strfn= "Your File Directory Path" + Convert.ToString(dt.Rows[0]["file_name"]);
            FileStream fs=new FileStream(strfn, 
                              FileMode.CreateNew, FileAccess.Write);
            fs.Write(barrImg,0,barrImg.Length);
            fs.Flush();
            fs.Close();
       //now you can attache you file to email here your file is generate at path stored in "strfn" variable
    }
