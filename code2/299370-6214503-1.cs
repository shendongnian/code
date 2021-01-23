        public List<GestionProjet.Client> GetProjectClient()
        {
            return (from prj in db.Projets
                      join clt in db.Clients on prj.IDClient equals clt.ID
                                      select new ClientDTO
                                      {
                                          Name = clt.Name,
                                          ProjetName = prj.Title,
                                          ID = clt.ID
                                      }).ToList();
