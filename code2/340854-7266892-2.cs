     DataSet ds = new DataSet();
     using(SqlConnection cn = new SqlConnection("server=(local);database=AdminUserDB;Persist Security Info=True; uid=sa;pwd=P@swrd123"))
     {
            cn.Open();
            using(SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.U_User WHERE URI=@umail", cn))
            {
        da.SelectCommand.Parameters.AddWithValue("@umail", umail);
                 da.Fill(ds);
             }
     }
     string filename = "output.xml";
     using(FileStream myFileStream = new FileStream(filename, FileMode.Create))
     {
            using(XmlTextWriter myXmlWriter = new XmlTextWriter(myFileStream, Encoding.Unicode))
           {
                ds.WriteXml(myXmlWriter);
           }
     }
