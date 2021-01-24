     [HttpPost]
            public ActionResult AddStudent()
            {
                var student = new Student();
     
                // The TryUpdateModel will use data annotation to validate
                // the data passed over from the client. If any validation
                // fails, the error will be written to the "ModelState".
                var valid = TryUpdateModel(student);
     
                string studentPartialViewHtml = null;
                if (valid)
                {
                    // Add the student to the repository.
                    // In any pratical application, exception handling should be used
                    // when making data access. In this small example, I will just cross
                    // my finger to say "there is no chance to encounter exeption" when
                    // adding the student. Indeed, the chance of exception is very minimal
                    // when adding students to my small repositoty. If the validation is
                    // successful, I will simply tell the client that the student is added.
                    StudentRepository.AddStudent(student);
     
                    // Obtain the html string from the partial view "Students.ascx"
                    var students = StudentRepository.GetStudent();
                    studentPartialViewHtml = RenderPartialViewToString("Students", students);
                }
     
                return Json(new {Valid = valid,
                                 Errors = GetErrorsFromModelState(), 
                    StudentsPartial = studentPartialViewHtml
                });
            }
