    var results = xDocument.Descendants("DatiBeniServizi").Select(x => new {
        Codice = (string)x.Elements("DettaglioLinee").Elements("CodiceArticolo").Elements("CodiceValore").FirstOrDefault()?.Value,
        Descrizione = (string)x.Elements("DettaglioLinee").Elements("Descrizione").FirstOrDefault()?.Value,
        Quantita = (string)x.Elements("DettaglioLinee").Elements("Quantita").FirstOrDefault()?.Value,
        PrezzoUnitario = (string)x.Elements("DettaglioLinee").Elements("PrezzoUnitario").FirstOrDefault()?.Value,
        AliquotaIVA = (string)x.Elements("DettaglioLinee").Elements("AliquotaIVA").FirstOrDefault()?.Value
    }).ToList();
