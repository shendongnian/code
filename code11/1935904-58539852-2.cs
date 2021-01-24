    var teachers = Students.GroupBy(x => new { x.Teacher.Name, x.Teacher.Age} )
                          .Select(gr => new {
                              TeacherName = gr.Key.Name,
                              TeacherAge = gr.Key.Age,
                              students = gr.ToList(),
                          });
