    using (WeightScaleEntities db = new WeightScaleEntities())
            {
                var deleteUserActivities = (from details in db.User_Activity
                                           where details.Id == i_UserActivityId
                                           select details).ToList<User_Activity>(); //<User_Activity> her name of your DbSet
                foreach(deleteObject in deleteUserActivities)
                {
                    db.Entry(deleteObject).State = System.Data.Entity.EntityState.Deleted;    
                }
                db.SaveChanges();
            }
