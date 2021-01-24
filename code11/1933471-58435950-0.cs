    public Numerador_mdfe Numerador_Get_id()
    {
            List<DbParameter> parameterList = new List<DbParameter>();
            Numerador_mdfe Numerador =null;
    
            string sql = "SELECT top 1 Numerador001,Numerador002,acesso FROM Numerador_mdfe order by Numerador001";
            using (DbDataReader dataReader = base.GetDataReader(sql,
                                                                parameterList,
                                                                CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    if (dataReader.Read())
                    {
                        Numerador = new Numerador_mdfe();
                        Numerador.Numerador001 = dataReader["Numerador001"]?.ToString().Trim();
                        Numerador.Numerador002 = Convert.ToInt32(dataReader["Numerador002"]);
                        Numerador.acesso = dataReader["acesso"]?.ToString().Trim();
                        Numerador_Lista.Add(Numerador);
                    }
                }
            }
        return Numerador ;
    }
