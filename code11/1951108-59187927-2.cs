    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase {
    
        //...
    
        //GET api/department/5/students
        [HttpGet("{id:int}/students")]     
        public async Task<ActionResult<DepartmentStudentsResponse>> GetStudents(int id) {
            var department =  await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();
            DepartmentStudentsResponse departmentStudents = new DepartmentStudentsResponse() {
                department = department
            };
            var listOfStudents = await _context.Students.Where(x => x.DepartmentId == id).ToListAsync();
            departmentStudents.students = listOfStudents;
            return departmentStudents;            
         }
    }
