    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase {
    
        //...
    
        //GET api/department/5/students
        [HttpGet("{id:int}/students")]     
        public async Task<ActionResult<DepartmentStudentsResponse>> GetStudents(int id) {
            DepartmentStudentsResponse departmentStudents = new DepartmentStudentsResponse();
    
            var department =  await _context.Departments.FindAsync(id);
            if (department != null) {
                departmentStudents.department = department;
    
                var listOfStudents = await _context.Students.Where(x => x.DepartmentId == id).ToListAsync();
                departmentStudents.students = listOfStudents;
                return departmentStudents;
            } else {
                return NotFound();
            }
         }
    }
