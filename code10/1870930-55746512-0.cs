    public class UsersController : ApiController
    {
        // Before
        private typeDB1 db = new typedb1();
        private typeDB2 db2 = new typedb2();
        [ResponseType(typeof(User))]
        [Route("api/users/{id}/{bdatos}")]
        public IHttpActionResult GetUser(long id, string bdatos)
        {
            try
            {
                if(bdatos == "typeDB1")
                {
                    typeDB1.User userdb1 = typeDB1.Find(id);
                    if (userdb1 == null)
                    {
                        return NotFound();
                    }
                    return Ok(userdb1);
                }
                else
                {
                    typeDB2.User userdb2 = typeDB2.Find(id);
                    if (userdb2 == null)
                    {
                        return NotFound();
                    }
                    return Ok(userdb2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Now
        private typeDB1 db = new typedb1();
        private typeDB2 db2 = new typedb2();
        private Dictionary<string, dynamic> dbDictionary = new Dictionary<string, dynamic>
        {
            ("typeDB1", db),
            ("typeDB2", db2)
        };
        [ResponseType(typeof(User))]
        [Route("api/users/{id}/{bdatos}")]
        public IHttpActionResult GetUser(long id, string bdatos)
        {
            try
            {
                dynamic certificate = dbDictionary[bdatos].Find(id);
                if (certificate == null)
                {
                    return NotFound();
                }
                return Ok(certificate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
