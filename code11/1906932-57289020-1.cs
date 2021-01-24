    foreach (int idUor in visibilitaPostRidistribuzioni)
    {
        var uor = UorSQL.GetUorFromId(siglaAOO, idUor, dbConfig);
        if(!visibUtils.Uors.Any(a => a.Equals(uor))
        {
            visibUtils.Uors.Add(uor);
        }
    }
