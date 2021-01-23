    var query = from grade in sc.StudentGrade
                            join student in sc.Person on grade.Person.PersonID
                                          equals student.PersonID
                            select new
                            {
                                FirstName = student.FirstName,
                                LastName = student.LastName,
                                Grade = grade.Grade.Value >= 4 ? "A" :
                                            grade.Grade.Value >= 3 ? "B" :
                                            grade.Grade.Value >= 2 ? "C" :
                                            grade.Grade.Value != null ? "D" : "-"
                            }; 
