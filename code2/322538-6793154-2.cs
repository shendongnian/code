    public class StudentsController: Controller
    {
        private readonly IStudentsRepository _repository;
        public StudentsController(IStudentsRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult LookUpStudentId(string id)
        {
            var student = _repository.GetStudent(id);
            if(student == null)
            {
                return new RedirectResult("~/Error/NotFound");
            }
            return View(student);
        }
    }
