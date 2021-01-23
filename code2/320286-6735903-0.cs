    using (DbContext db = new DbContext())
                {
                    db.Details.Add(details);
                    db.SaveChanges();
                    newID = details.DetailsID;
                    AccessRepository rep = new AccessRepository();
                    AccessDetails detailUpdate = rep.GetByID(newID);
                    detailUpdate.Imported = true;
                    db.SaveChanges();
                }
