                var db = new PetaPoco.Database("MyDB");
    
                try
                {
                    db.BeginTransaction();
                    foreach (var item in NewData)
                    {
                        db.Execute("UPDATE MyTable SET ColA= @0 WHERE ColB = @1",item.PropertyA, item.PropertyB);
                    }
                    db.CompleteTransaction();
    
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                }
