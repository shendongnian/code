    public bool AddRevendaCliente(string revendaId, RevendaCliente requestRevendaClient)
    {
        try
        {
            var filter = Builders<Revenda>.Filter.Eq(s => s.Id, revendaId);
    
            // Get a reference to the parent parent "Revenda"
            var parentObject = CollRevendas.Find<Revenda>(filter).FirstOrDefault();
            parentObject.Clientes.Add(requestRevendaClient);
    
            // Update the parent object "Revenda"
            var result = CollRevendas.ReplaceOneAsync(filter, parentObject);
        }
        catch (Exception ex)
        {
            throw;
        }            
        return true;
    }
