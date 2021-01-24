    using (SqlConnection sqliteCon = new SqlConnection(connection))
    {
        sqliteCon.Open();
        var values = new List<string>();
        var query = "SELECT ResItem AS RD FROM tSE JOIN tL ON tSE.idSE=tL.idL WHERE tL.Selection=1";
        using (SqlCommand cmdRD = new SqlCommand(query, sqliteCon))
        {
            var RD = cmdRD.ExecuteScalar();
            using (SqlDataReader reader = cmdRD.ExecuteReader())
            {
                while (reader.Read())
                {
                    values.Add(reader[0].ToString());
                }
            }
        }
        int generatedId = 0;
        var query2 = "INSERT INTO tSD(NomeItem,ResItemDet,DateStartDet,DateEndDet) OUTPUT inserted.Id VALUES (@NI,@RProva,@DATESE,@DATEED)";
        using (SqlCommand cmd1 = new SqlCommand(query2, sqliteCon))
        {
            foreach (var value in values)
            {
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@DATESE", DATESE);
                cmd1.Parameters.AddWithValue("@DATEED", DATEED);
                cmd1.Parameters.AddWithValue("@NI", NI);
                if (value.Equals(pass))
                {
                    cmd1.Parameters.AddWithValue("@RProva", value);
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@RProva", fail);
                }
                cmd1.ExecuteNonQuery();
            }
            generatedId = Convert.ToInt32(cmd1.ExecuteScalar());
        }
        var query3 = "UPDATE tSE SET FK_TSD_id = @tsdId FROM tL JOIN tSE ON tL.idL = tSE.idSE WHERE tL.Selection=1 ";
        using (SqlCommand cmd2 = new SqlCommand(query3, sqliteCon))
        {
            cmd2.Parameters.AddWithValue("@tsdId", generatedId);
            cmd2.ExecuteNonQuery();
        }
    }
