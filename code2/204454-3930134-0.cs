    public string GetDocument()
    {
        try
        {
            // Are you sure vProcesso is not null?
            if (vProcesso == null)
                return null;
            // Only create the context if it wasn't already created,
            if (db == null)
                db = new RENDBDataContext();
            return db.Processo_has_Servicos
                .Where(ps => ps.Processo_Id == vProcesso.Id && ps.Servico.Document != null)
                .Select(ps => ps.Servico.Document) // use an implicit join
                .SingleOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
