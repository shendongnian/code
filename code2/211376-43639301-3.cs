    public class ThingsController : ODataController
    {
        private myDbModel db = new myDbModel();
        /// <summary>
        /// Only exposes ActiveThings (not DeletedThings)
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public IQueryable<Thing> GetThings()
        {
            return db.ActiveThings;
        }
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            using (var context = new myDbModel())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Thing thing = await db.Things.FindAsync(key);
                    if (thing == null || thing is DeletedThing) // love the simple expressiveness here
                    {
                        return NotFound();//was already deleted previously, so return NotFound status code
                    }
                    //soft delete: converts ActiveThing to DeletedThing via direct query to DB
                    context.Database.ExecuteSqlCommand(
                        "UPDATE Things SET Discriminator='D', DeletedOn=@NowDate WHERE Id=@ThingId", 
                        new SqlParameter("@ThingId", key), 
                        new SqlParameter("@NowDate", DateTimeOffset.Now)
                        );
                    context.ThingTransactionHistory.Add(new Ross.Biz.ThingStatusLocation.ThingTransactionHistory
                    {
                        ThingId = thing.Id,
                        TransactionTime = DateTimeOffset.Now,
                        TransactionCode = "DEL",
                        UpdateUser = User.Identity.Name,
                        UpdateValue = "MARKED DELETED"
                    });
                    context.SaveChanges();
                    transaction.Commit();
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
