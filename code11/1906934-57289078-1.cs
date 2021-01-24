    var interimSet = new HashSet<UOR>();
    foreach (int idUor in visibilitaPostRidistribuzioni)
    {
        var uor = UorSQL.GetUorFromId(siglaAOO, idUor, dbConfig);
        interimSet.Add(uor); //which is the same as: if(!interimSet.Contains(uor))interimSet.Add(uor);
    }
    
    visibUtils.Uors.AddRange(interimSet);
