string sql = @"INSERT INTO concediati (nume, prenume, idcar, idrent, idclient) VALUES (@name, @lastname, @car, @rent, @client)";
using (SqlConnection conn = new SqlConnection(stringcon))
{
    using (SqlCommand comm = new SqlCommand(sql, conn))
    {
        comm.Parameters.Add(new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Size = 50 });
        comm.Parameters.Add(new SqlParameter { ParameterName = "@lastname", SqlDbType = SqlDbType.VarChar, Size = 50 });
        comm.Parameters.Add(new SqlParameter { ParameterName = "@car", SqlDbType = SqlDbType.Int });
        comm.Parameters.Add(new SqlParameter { ParameterName = "@rent", SqlDbType = SqlDbType.Int });
        comm.Parameters.Add(new SqlParameter { ParameterName = "@client", SqlDbType = SqlDbType.Int });
        conn.Open();
        for (int i = 0; i < bunifuCustomDataGrid2.Rows.Count; i++)
        {
            string firstName = Convert.ToString(bunifuCustomDataGrid2.Rows[i].Cells["firstname"].Value);
            string lastName = Convert.ToString(bunifuCustomDataGrid2.Rows[i].Cells["lastname"].Value);
            int car = Convert.ToInt32(bunifuCustomDataGrid2.Rows[i].Cells["CARS"].Value);
            int rent = Convert.ToInt32(bunifuCustomDataGrid2.Rows[i].Cells["RENT"].Value);
            int client = Convert.ToInt32(bunifuCustomDataGrid2.Rows[i].Cells["CLIENT"].Value);
            comm.Parameters["@name"].Value = firstName;
            comm.Parameters["@lastname"].Value = lastName;
            comm.Parameters["@car"].Value = car;
            comm.Parameters["@rent"].Value = rent;
            comm.Parameters["@client"].Value = client;
            comm.ExecuteNonQuery();
        }
    }
}
