        int O_id =Convert.ToInt32(textBox2.Text);
                SqlConnection cn = new SqlConnection(strCn);
                SqlCommand cmd = new SqlCommand("INSERT INTO BLOBTest (BLOBData, O_id) VALUES (@BLOBData,'"+O_id+"')", cn);
                String strBLOBFilePath = textBox1.Text;//Modify this path as needed.
               
                //Read jpg into file stream, and from there into Byte array.
                FileStream fsBLOBFile = new FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read);
                Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
                fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                fsBLOBFile.Close();
                //Create parameter for insert command and add to SqlCommand object.
                SqlParameter prm = new SqlParameter("@BLOBData", SqlDbType.VarBinary, bytBLOBData.Length, ParameterDirection.Input, false,
                            0, 0, null, DataRowVersion.Current, bytBLOBData);
                cmd.Parameters.Add(prm);
                //Open connection, execute query, and close connection.
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Picture has been uploaded");
                cn.Close();
                
