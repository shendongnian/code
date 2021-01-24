    using (Context context = new Context())
                    {
    
                        var cv =
                                        (
                                            from c in context.CVs
                                            where c.Id == id && c.PersonneId == userId
                                            select new CVVM
                                            {
                                                Titre = c.Titre,
                                                MontrerPhoto = c.MontrerPhoto,
                                                Layout = c.Layout,
                                                Id = id,
                                                FormAction = "EditionTraitement",
                                                FormTitre = "Edition de ce CV",
    
                                                 Formations = from form in c.Formations
                                                              where c.Id == id && c.PersonneId == userId
                                                              select new FormationVM
                                                             {
                                                                 Id = form.Id,
                                                                 DateDebut = form.DateDebut,
                                                                 DateFin = form.DateFin,
                                                                 Ecole = form.Ecole,
                                                                 Description = form.Description,
                                                                 Diplome = form.Diplome
                                                             }
    
                                            }).FirstOrDefault();
    
    }
