        static public WillyDemandes GetFirst()
        {
    
       WillyDemandes willyDemandes = ContextProvider.db.WillyDemandes
                    .Include(x => x.IdPartNavigation)
                    .Include(x => x.WillyMachines)
                    .Where(x => x.Statut == Statuts.EnTest.ToString() && x.Username == Environment.UserName)
                    .OrderBy(x => x.Priority)
                    .ThenBy(x => x.Id)
                    .FirstOrDefault();
    
            if (willyDemandes != null)
            {
                willyDemandes.Statut = Statuts.EnTraitement.ToString();
                willyDemandes.ServerName = Environment.MachineName;
                willyDemandes.DateDebut = DateTime.Now;
                ContextProvider.db.SaveChanges();
            }
    
            return willyDemandes;
    
        }
