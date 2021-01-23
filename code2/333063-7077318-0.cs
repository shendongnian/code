    public List<string> getItems(string codigodestino, string pendiente)
    {
        List<string> _items = new List<string>();
        SqlCeConnection con = new SqlCeConnection(Globals.conString);
        string Qyery = "SELECT codbultocomp FROM envios WHERE codigodestino='" + codigodestino + "' AND estado='" + pendiente +"'";
        try
        {
            con.Open();
            SqlCeCommand cmd = new SqlCeCommand(Qyery, con);
            cmd.CommandType = CommandType.Text;
            SqlCeDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                _items.Add((string)reader["codbultocomp"]);
            }
            con.Close();
            return _items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
