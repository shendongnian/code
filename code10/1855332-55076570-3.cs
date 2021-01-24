    public class MyApiController : ApiController {
        //...
    
        public IHttpActionResult MyControllerAction() {
            var result = myService.GetNames()
                        .Select(student => select new { //<-- Note what was done here
                              StudentID = student.StudentID,
                              StudentName = student.StudentName,
                              Email = student.Email,
                              IsDeleted= student.IsDeleted
                          });
            return Ok(result.ToList());
        }
    }
