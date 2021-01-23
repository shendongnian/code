            try
            {
                //Read Image Bytes into a byte array
                byte[] blob = ReadFile(txtPath.Text);
                //Initialize Oracle Server Connection
                con = new OracleConnection(conString);
                //Set insert query
                string qry = "insert into Imgpn (imgpath,photo) values('" + txtPath.Text + "'," + " :BlobParameter )";
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleType = OracleType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = blob;
                //Initialize OracleCommand object for insert.
                cmd = new OracleCommand(qry, con);
                //We are passing Name and Blob byte data as Oracle parameters.
                cmd.Parameters.Add(blobParameter);
                //Open connection and execute insert query.
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Image added to blob field");
                GetImagesFromDatabase();
                cmd.Dispose();
                con.Close();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;
            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);
            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        void GetImagesFromDatabase()
        {
            try
            {
                //Initialize Oracle  connection.
                con = new OracleConnection(conString);
                //MessageBox.Show("Connection Successfull");
                //Initialize Oracle adapter.
                OracleDataAdapter oda = new OracleDataAdapter("Select * from Imgpn", con);
                //Initialize Dataset.
                DataSet DS = new DataSet();
                //Fill dataset with ImagesStore table.
                oda.Fill(DS, "Imgpn");
                //Fill Grid with dataset.
                dataGridView1.DataSource = DS.Tables["Imgpn"];
                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
