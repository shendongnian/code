    // get the objects on db
    var list = db.VeiculoComSeminovo.ToList();
    // lists to recive data    
    List<int> totaisFamilia = new List<int>();
    List<int> totaisFamiliaComSN = new List<int>();
    // loop to cycle through objects and add the values ​​I need to their lists
    foreach (var item in ViewBag.familias)
    {
    totaisFamilia.Add(list.Count(a => a.descricaoFamiliaNovo == item && a.valorSeminovo == null));
    totaisFamiliaComSN.Add(list.Count(a => a.descricaoFamiliaNovo == item && a.valorSeminovo != null));
    }
