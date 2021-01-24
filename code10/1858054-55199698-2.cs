	public async Task<IEnumerable<Articolo>> GetArticoliByDivisioneAsync(string divisione)
	{
		return await _ctx.Articoli
			.Where(a => a.Divisione == divisione
					  && a.Category!= "001"
					  && a.Varianti.Any(v=>v.Active == 1))
			.Include(i => i.FotoArticoli)               
			.ToListAsync();
	}
