            //...
            try
            {
                if (IsEditMode.Equals("false"))
                {
                    _studentRepository.Create(student);
                    UploadFile(file, student.Id);
                    _toastNotification.AddSuccessToastMessage("Student has been created successfully.");
                }
                else
                {
                    //edit mode
                    if(file == null)//Updating fields without updating the image.
                    {
                        var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
                        if (existingStudent != null)
                        {
                            // updating student with previousImageUrl
                            student.ImageUrl = existingStudent.ImageUrl;
                            _context.Entry(existingStudent).CurrentValues.SetValues(student);
                            _context.Entry(existingStudent).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                    }
                    else//Updating the fields and the image
                    {
                        _studentRepository.Edit(student);
                        UploadFile(file, student.Id);
                    }
                    
                    _toastNotification.AddSuccessToastMessage("Student has been edited successfully.");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public void UploadFile(IFormFile file, long studentId)
        {
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            var student = _studentRepository.GetSingleStudent(studentId);
            student.ImageUrl = fileName;
            _studentRepository.Edit(student);
        }
        
       public void Edit(Student student)
        {
            var existingStudent = _context.Students
                .FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                // updating student.
                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                _context.Entry(existingStudent).State = EntityState.Modified;
                _context.SaveChanges();
           }
        }
