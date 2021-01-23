            // Insert existing object in data base via EF, but PK is missing ...
            using (var Es = new MyEntities())
            {
                try
                {
                    // Allows you to get next pk
                    var e = new  Model.TableXXX();
                    // Set pk to existing entity which has no pk
                    existingEntity.PkField = e.PkField;
                    // Save existing object and let garbage collector take care
                    // of newly created entity
                    Es.TableXXX.AddObject(existingEntity);
                    Es.SaveChanges();
                }
                catch (Exception ex)
                {
                    // implement exception
                }
            }
