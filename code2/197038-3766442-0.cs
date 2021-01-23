    public List<T> LoadData<T> (String query) {
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader rdr = cmd.ExecuteReader();
        List<T> list = new List<T>();
        while (rdr.Read())
        {
            T p = new T(rdr[0]);
            list.Add(p);
        }
        rdr.Close();
        return list;
    }
