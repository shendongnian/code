    [AttributeUsage(AttributeTargets.Class)]
    public class RequireStudentInfoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var student = value as StudentLogin;
            if(student == null)
            {
                return false;
            }
            if (student.StudentId.HasValue || !string.IsNullOrEmpty(student.SSN))
            {
                return true;
            }
            return false;
        }
    }
