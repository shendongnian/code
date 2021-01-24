    if (!DBNull.Value.Equals(linha["id"])) 
    {
        this.Medico = new MedicoModel(Int32.Parse(linha["id"].ToString()),
                                            linha["nome"].ToString(),
                                            linha["crm"].ToString(),
                                             
        Boolean.Parse(linha["habilitado"].ToString()));
    }
    
