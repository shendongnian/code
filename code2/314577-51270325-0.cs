            SqlConnection cnn;            
            SqlDataAdapter dad;
            DataSet dts = new DataSet();
            cnn = new SqlConnection(textDataSource);
            dad = new SqlDataAdapter(StrSql, cnn);
            try
            {
                cnn.Open();
                dad.Fill(dts);
                cnn.Close();
                
                return dts;
            }
            catch (Exception)
            {
                return dts;
            }
            finally
            {
                dad.Dispose();
                dts = null;
                cnn = null;
            }
        }
