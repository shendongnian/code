    // second way
            using (WeightScaleEntities db = new WeightScaleEntities())
            {
                var deleteUserActivities = (from details in db.User_Activity
                                            where details.Id == i_UserActivityId
                                            select details).SingleOrDefault();
                if (deleteUserActivities != null)
                {
                    db.User_Activity.Remove(deleteUserActivities);
                    // or use this line
                    //db.Entry(deleteUserActivities).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
