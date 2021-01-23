    string mystring = "GradeId1:StudentName1*StudentName2*StudentNameN,GradeId2:StudentName1*StudentName2*StudentNameN,GradeIdN:Student1*StudentName2*StudentNameN";
    MatchCollection matches = 
       Regex.Matches(
          mystring,
          @"(?:GradeId(\w+):(?:([\w ]+)(?:$|\*|(?=\,)))+)(?:,|$)");
    var grades = matches.Cast<Match>().Select(
       gradeMatch => 
          new
          {
             Grade = gradeMatch.Groups[1].Value,
             Students = gradeMatch.Groups[2].Captures
                .Cast<Capture> ()
                .Select (c => c.Value).ToList ()
          });
    foreach (var grade in grades)
    {
       Console.WriteLine("Grade: " + grade.Grade);
       foreach (string student in grade.Students)
          Console.WriteLine("   " + student);
    }
