 public void SaveXmlTestData_WithString()
        {
            //<?xml version=""1.0"" encoding=""UTF-8""?><!DOCTYPE plist PUBLIC"">
            string xdata = @"<note><to>profile</to></note>";
            var samples= GetSamplesTvp(1, xdata);
            using (DbCommand cmd = database.GetStoredProcCommand("XmlTvpSprocTest"))
            {
                var param1 = new SqlParameter("@SamplesTvp ", samples) { SqlDbType = SqlDbType.Structured };
                cmd.Parameters.Add(param1);
                database.ExecuteNonQuery(cmd);
            }
        }
private List<SqlDataRecord> GetSamplesTvp(int Id, string xmldata)
        {
            List<SqlDataRecord> tvprecord = new List<SqlDataRecord>();
            var column1 = new SqlMetaData("Id", SqlDbType.Int);
            var column2 = new SqlMetaData("Profiles", SqlDbType.Xml);
            var data = new SqlMetaData[] { column1, column2 };
            var sqlrecord = new SqlDataRecord(data);
            sqlrecord.SetValue(0, Id);
            sqlrecord.SetValue(1, xmldata);
            tvprecord.Add(sqlrecord);
            return tvprecord;
        }
Although, I do get an exception if I add the commented out xml to the xmlData 
