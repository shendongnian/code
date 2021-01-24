     protected void btn_Click(object sender, EventArgs e)
        {
         
            if (FileUpload1.HasFile)
            {
                DataTable dt = ReadExcelData(@"your Excel Document Path");
                foreach (DataRow dr in dt.Rows)
                {
                    //Your Code to insert record into the database
                }
            }
        }
