    public async Task AddInterakcijaAsync(int korisnikoIme, int projekatIme)
    {
        using (ExtentBazaEntities _context = new ExtentBazaEntities())
        {
            var korisniko = _context.Korisnik.Single(a => a.KorisnickoIme == korisnickoIme)
            var projekat = _context.Projekat.Single(a => a.ProjekatIme == projekatIme);
            korisniko.Projekat.Add(projekat);
            await _context.SaveChangesAsync();
        }
    }
