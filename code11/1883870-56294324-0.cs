            WillyMachines willyMachines = willyDemandes.WillyMachines
                                                       .Where(x => x.DocumentType == MachineName)
                                                       .FirstOrDefault();
            if (willyMachines == null)
            {
                var otherMachines = new WillyMachines{ 
                   IdDemande = willyDemandes.Id, 
                   DocumentType = MachineName 
                   WillyMachines.Add(willyMachines);            
                   DateDebut = DateTime.Now;
                   DateFin = null;
                   Performance = null;
                   Statut = Statuts.EnTraitement.ToString()
               };
           }
           db.SaveChanges();
