    private List<Student> studentList = new List<Student>();
    [WebMethod]
    public void AddStudent(Student student) 
    {
        studentList.Add(student);
    }
    [WebMethod]
    public Student[] GetStudent() 
    {
        return studentList.ToArray();
    }
