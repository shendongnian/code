    namespace Model{
    class Student
    {
        public string Name { get; set; }
        public String Address { get; set; }
        // more student properties here ..
        // No methods like SaveStudent in this class , thats up into the business layer
        public bool IsValid(){ // validate the student here }
    }
}
    namespace Business{
    class Student
    {
        // call this method from your Presentation layer
        public void SaveStudent(Model.Student student)
        {
            if (student.IsValid())
            {
                DataAccess.StudentDAO student = new DataAccess.StudentDAO();
                student.SaveStudent(student);
            }
            else
            {
                throw new ApplicationException("Invalid student");
            }
        }
    }
