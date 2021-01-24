    public string CallSproc(string sprocName, params Variable[] variables)
    {
    
    ...
        variables.ToList()
                 .ForEach(param =>  cmd.Parameters.AddWithValue(param.Name, param.Value);
    ...
        
    }
