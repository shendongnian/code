    public async Task<ParagemRegisto> GetParagemRegistoOnGoingAsync(int registoId)
      {
            var result = await _context.ParagensRegistos
                .Where(pr => pr.RegistoId == registoId && pr.HoraFim == null)
                .FirstOrDefaultAsync();
    
            return result ?? new List<ParagemRegisto>();
      }
