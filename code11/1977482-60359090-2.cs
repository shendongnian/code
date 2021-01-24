    // Make Student class partial and extend it with clone method.
    // This is helpful for generated entities not using the code-first approach.
    public partial class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public partial class Student
    {
        public Student Clone()
        {
            return new Student
            {
                Id = Id, // Copies value not reference
                LastName = LastName, // string is immutable this OK
                FirstName = FirstName, // string is immutable this OK
                // DateTime is a struct I think so it should pass value
                EnrollmentDate = EnrollmentDate, // Verify my assumption
                /* If you are changing navigational properties you need to clone them
                 * or the same thing can happen. */
                Enrollments = Enrollments.Select(enrollment => enrollment.Clone())
            };
        }
    }
