    // get the deserialize object
    var dto = Deserialize(); 
    // create a new instance of Student from the dto
    var newStudent = new Student
    {
        StudentName = dto.StudentName,
        Age = dto.Age,
        Address = dto.Address,
        Major = dto.Major,
        PhoneNumber = dto.PhoneNumber
    }; 
    // save it to the database
    using (var context = new UNIEntities1())
    {
        context.Student.Add(newStudent);
        context.AcceptChanges(); // or SaveChanges()
    }
