     var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);
    .Linq;
    namespace MTBCTest.Controllers
    {
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private testingDbEntities db = new testingDbEntities();
        // GET: api/Users
        [HttpGet]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
         }
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User ob = db.Users.Find(user.ID);
            ob.FirstName = user.FirstName;
            ob.LastName = user.LastName;
            ob.Password = user.Password;
            ob.EmailID = user.EmailID;
            db.Entry(ob).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
          
         }
        // POST: api/Users
         [HttpPost]
         public IHttpActionResult PostUser(User user)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         
            db.InserUser(user.FirstName,user.LastName,user.EmailID, user.Password);
            db.SaveChanges();
           
            return Ok();
        }
        // DELETE: api/Users/5
        [HttpGet]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
        }
        }
