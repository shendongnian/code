                var db = new PetaPoco.Database("MyDB");
    
                try
                {
                    db.BeginTransaction();
                    foreach (var item in NewData)
                    {
                        db.Execute("UPDATE MyTable SET ColA= '" + item.PropertyA+ "' WHERE ColB = '" + item.PropertyB+ "'");
                    }
                    db.CompleteTransaction();
    
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                }
