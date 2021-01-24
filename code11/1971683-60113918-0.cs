    if(!linha["id"].IsNull()) {
        this.Medico = new MedicoModel(Int32.Parse(linha["id"].ToString()),
                                 linha["nome"].ToString(),
                                 linha["crm"].ToString(),
                                 Boolean.Parse(linha["habilitado"].ToString()));
