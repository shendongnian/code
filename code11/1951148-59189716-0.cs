        public class StudentController : Controller
        {
          // your code
         }
        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> GetStudents()
        {
            using (var context = new UNIEntities1())
            {
                var list = await context.StudentDto.ToListAsync();
                return Json(list,JsonRequestBehavior.AllowGet);
            }
        }
