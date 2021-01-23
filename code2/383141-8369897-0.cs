    var estadosDeAlma = "";
    foreach (var item in db.EstadosDeAlma.ToList())
    {
        estadosDeAlma += item.Title + " ";
    }
    ViewBag.EstadosDeAlma = estadosDeAlma;
