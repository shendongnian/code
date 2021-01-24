	public async Task<IEnumerable<Articolo>> GetArticoliByDivisioneAsync(string divisione)
	{
		return await _ctx.Articoli
			.Where(a => a.Divisione == divisione
					  && a.Category!= "001"
					  && a.Varianti.Active == 1)
			.Include(i => i.Varianti)
			.Include(i => i.FotoArticoli)               
			.ToListAsync();
	}
