    public DataSet getComputer(int id) // you don't need to pass int by ref unless you're planning on changing it inside this method
    {
        DataSet data = new DataSet();
        using (SqlConnection conn = new SqlConnection("Server=JURA;Database=ReadyForSeven;User id=;Password=")) {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM computers WHERE id = @id", conn)) {
                cmd.Parameters.AddWithValue("id", id);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                    da.Fill(data);
                    return data;
                }
            }
        }
    }
