        StringBuilder Par1 = new StringBuilder("");
        StringBuilder Par2 = new StringBuilder("");
        for (var i = 0; i < MyObject.Length; i++)
        {
            if (i > 0)
            {
                Par1.Append(",");
                Par2.Append(",");
            }
            Par1.Append(MyObject[i].Prop1);
            Par2.Append(MyObject[i].Prop2);
        }
        myCommand.Parameters.Add(new SqlParameter("@Par1", Par1.ToString()));
        myCommand.Parameters.Add(new SqlParameter("@Par2", Par2.ToString()));
        myCommand.CommandText = "MyStoredProcedure";
        myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        myCommand.ExecuteNonQuery();
