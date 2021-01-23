            var query = from personne in clients
                        where personne.CliID == guid
                            && personne.Meetings.Any() // simulate `INNER JOIN` 
                                                       // retirer les gens sans réunions
                                                       // pardonne mon français terrible, STP
                        select new Parcour
                        {
                            //ID = i++,
                            Nom = personne.Nom,
                            Prénom = personne.Prenom,
                            Structure = personne.Structure,
                            Début = personne.Meetings.Min(m => m.Start),
                            Fin = personne.Meetings.Max(m => m.Start),
                            Dispositif = personne.Dispositifs,
                        };
