     public void CloneStudent(Guid studentId)
        {
            // Get existing student
            Student student = _session.Get<Student>(studentId);
            // Copy by reference
            Student newStudent = student;
            
            // Reset Id to do quick and dirty clone
            newStudent.Id = Guid.NewGuid();
            newStudent.Sticker = "D";
            // Must evict existing object or Nhibernate will throw object modified error
            _session.Evict(student);
            // Save new object
            _session.Save(newStudent);
            _session.Flush();
        }
