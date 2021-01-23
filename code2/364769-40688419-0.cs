    // first way
            using (WeightScaleEntities db = new WeightScaleEntities())
            {
                var deleteUserActivities = from details in db.User_Activity
                                           where details.Id == i_UserActivityId
                                           select details;
                if (deleteUserActivities.Count() > 0)
                {
                    db.deleteUserActivities.Remove(deleteUserActivities.First());
                    db.SaveChanges();
                }
            }
