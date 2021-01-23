    List<StudentDetails> studentList = new List<StudentDetails>();
    using (StreamReader sr = new StreamReader(@"filename"))
    {
        
        string line;
        while (!sr.EndOfStream)
        {
            StudentDetail student;
            
            student.unitCode = sr.ReadLine();
            student.unitNumber = sr.ReadLine();
            student.firstName = sr.ReadLine();
            student.lastName = sr.ReadLine();
            student.studentMark = Convert.ToInt32(sr.ReadLine());
 
            studentList.Add(student);
        }
        StudentDetail[] studentArray = studentList.ToArray();
    }
