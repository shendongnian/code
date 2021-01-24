     public async Task<bool> IsParagemOnGoingAsync(int registoId)
        {
           return await _context.ParagensRegistos
               .Where(pr => pr.RegistoId == registoId)
               .AnyAsync(pr => pr.HoraFim == null);
        }
