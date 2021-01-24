    public class MyBaseController<T> : ApiController
    {
        public IHttpActionResult InsertData([FromBody] T model)
        {
            //Write the generic code here, for example:
            dbContext.Set<T>().Add(model);
            dbContext.SaveChanges();
            return some value;            
        }
    }
