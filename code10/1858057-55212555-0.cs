    public async Task<IEnumerable<Articolo>> GetArticoliByDivisioneAsync(string divisione)
    {
        return await _ctx.Articoli
                         .Where(a => a.Divisione == divisione
                                     && a.Category!= "001")
                         .Include(i => i.Varianti)
                         .Include(i => i.FotoArticoli)               
                         .Select(x => new Articolo
                        {
                            Codice = x.Codice ,
                            Prezzo = x.Prezzo ,
                            Varianti = x.Varianti.Where(v => v.attivo== 0).ToList(),
                            FotoArticoli = x.FotoArticoli
                        })           
                    .ToListAsync();
    }
