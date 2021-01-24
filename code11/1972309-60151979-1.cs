    db.Students
                      .Include(b => b.Course)
                      .Select(b => new StudentDTO()
                      {
                          Id = b.Id,
                          FirstName = b.FirstName,
                          Course = db.Courses
                                   .Where(c => c.Id == b.Course.Id)
                                   .Select(c => new CourseDTO()
                                   {
                                       Id = c.Id,
                                       Title = c.Title,
                                       NumberOfStudents = c.Student.Count()
                                   })
                                   .FirstOrDefault()
                      }).ToList();
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Status { get; set; }
        public int IdCourse { get; set; }
        public CourseDTO Course { get; set; }
    }
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfStudents { get; set; }
        public List<StudentDTO> Student { get; set; }
    }
        
