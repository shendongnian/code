     public void SavePicture()
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Integrated security=true;database=databasename");
            SqlDataAdapter da = new SqlDataAdapter("select top 100 [Name] ,[Picture] From tablename", con);
            SqlCommandBuilder MyCB = new SqlCommandBuilder(da);
            DataSet ds = new DataSet("tablename");
            byte[] MyData = new byte[0];
            da.Fill(ds, "tablename");
            DataTable table = ds.Tables["tablename"];
               for (int i = 0; i < table.Rows.Count;i++ )               
                   {
                    DataRow myRow;
                    myRow = ds.Tables["tablename"].Rows[i];
                    MyData = (byte[])myRow["Picture"];
                    int ArraySize = new int();
                    ArraySize = MyData.GetUpperBound(0);
                    FileStream fs = new FileStream(@"C:\NewFolder\" + myRow["Name"].ToString() + ".jpg", FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(MyData, 0, ArraySize);
                    fs.Close();
                   }
           
        }
