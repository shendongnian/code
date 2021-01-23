    public SqlConnection Conectar(string remoteMachine)
    {
          SqlConnection con = new SqlConnection(string.Format(@"Data Source={0}\sqlexpress;Initial Catalog=misnotas;Integrated Security=True", remoteMachine));
          return con;
    }
