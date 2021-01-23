    var studentGroups =
      from student in studentList
      group student by new {student.Age, student.Grade, student.LastName} into g2
      group g2 by new {g2.Key.Age, g2.Key.Grade} into g1
      group g1 by g1.Key.Age
    foreach(var group0 in studentGroups)
    {
       int age = group0.Key;
       foreach(var group1 in group0)
       {
         int grade = group1.Key.Grade
         foreach(var group2 in group1)
         {
           string lastName = group2.Key.LastName
           foreach(Student s in group2)
           {
              //...
           }
         }
       }
    }
