    public IHttpActionResult GetNames() {
        var result = (from student in db.tblStudents
                      select new { //<-- Note what was done here
                          StudentID = student.StudentID,
                          StudentName = student.StudentName,
                          Email = student.Email,
                          IsDeleted= student.IsDeleted
                      });
        return Ok(result.ToList());
    }
