    public ActionResult IndexStudents(Docent docent, int lessonId, int classId)
    {
      var studentModel = new StudentModel();
      var normalStudents = docent.ReturnStudentsNormal(lessonId, classId);
      foreach (var student in normalStudents)
      {
        studentModel.NormalStudents.Add(new SelectListItem() {Value = student.Key, Text = student.Value});
      }
      var studentsNoClass = docent.ReturnStudentsNormal(lessonId, classId);
      foreach (var student in studentsNoClass)
      {
        studentModel.StudentsNoClass.Add(new SelectListItem() {Value = student.Key, Text = student.Value});
      }
      return View(studentModel);
    }
