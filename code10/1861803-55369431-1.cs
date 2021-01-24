    public class MembersController: ApiController 
    {
        // ctor
        public MembersController()
        {
            _context = new ApplicationDbContext();
    
        }
    
        public IHttpActionResult GetMembers([FromBody] ViewModel model)
        {
            try
            {
                //Creating instance of DatabaseContext class  
                using (_context)
                {
                    var draw = model.Draw;
                    var start = model.Start;
                    var length = model.Length;
    
                    // skipped for brevity
     
                    return Ok(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data });
                }
                catch (Exception)
                {
                    // error handling
                }
            }
        }
    }
