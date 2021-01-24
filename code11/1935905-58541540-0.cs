    TeachersWithTheirStudents = students
        // Flatten the Student with his Teachers into StudentTeacherCombinations:
        .SelectMany(student => student.Teachers,
            (student, teacher) => new
            {
                Student = student,
                Teacher = teacher,
            })
        // GroupBy Teacher name:
        .GroupBy(studentTeacherCombination => studentTeacherCombination.Teacher.Name,
             (teacherName, studentTeacherCombinationsWithThisTeacherName) => new
             {
                 // All studentTeacherCombinations of teachers with TeacherName
                 // are expected to be equal, so we can just remember the first one:
                 Teacher = studentTeacherCombinationsWithThisTeacherName
                           .Select(studentTeacherCombi=> studentTeacherCombi.Teacher)
                           .FirstOrDefault(), // I'm sure there is at least one
                 StudentsOfTeacher = studentTeacherCombinationsWithThisTeacherName
                            .Select(studentTeacherCombi => studentTeacherCombi.Student),
             })
             // Finally put this into a Teacher object:
             .Select(teacherWithHisStudents => new Teacher()
             {
                 Id = teacherWithHisStudents.Teacher.Id,
                 Name = teacherWithHisStudents.Teacher.Name,
                 ... // other Teacher properties
                 Students = teacherWithHisStudents.StudentsOfTeacher
                            .Select(student => new Student()
                            {
                                Id = student.Id,
                                Name = student.Name,
                                ... // other Student properties
                            })
                            .ToList(),
        });
                 
             });
