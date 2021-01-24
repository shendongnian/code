    public class StudentAppService : IStudentAppService 
    {
        private readonly IRepository<Student> _studentRepository;
        
        public RoleAppService(IRepository<Student> studentRepository)
            : base(repository)
        {
           _studentRepository = studentRepository;
        }
        public override async void UpdateOnlyNameOfStudent(StudentDto input)
        {
            var student = _studentRepository.Get(input.Id);
            ObjectMapper.Map(input, student );
        }
    }
