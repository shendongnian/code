        public class ApiBaseController<T> : ApiController where T : class {
    
        [HttpPut]
        [Authorize]
        [ActionName("Update")]
        [Produces("application/json")]
        public T Put([FromBody]T entity) // Update
        {
            using (MyContext db = new MyContext()) 
            {
               repository.Update(updateElement);
               return entity;
            }
        }
        [HttpPost]
        [Authorize]
        [ActionName("Add")]
        [Produces("application/json")]
        public T Post([FromBody]T entity)//Add new record
        {
            try
            {
                lock (LockObjectAdd)
                {
                    using (MyContext db = new MyContext())
                    {
                        Repository<T> repository = new Repository<T>(db);
                        repository.Add(entity);
                        return entity;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    
        }
