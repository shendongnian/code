    public List<champions> LoadChampions()
    {
        using (NarachiContext NarachiCTX = new NarachiContext())
        {
            var champions = NarachiCTX.Campeones.Select(d => new champions
            {
               Name = d.Nombre
            }).ToList();
            return champions;
        }
    }
 
