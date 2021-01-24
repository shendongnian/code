    // I only want to show the following columns of students:
    var studentColumns = new Column<Student>
    { 
        new Column {Index = 1, Name = "Id", PropertyValueSelector = student => student.Id },
        new Column {Index = 3, Name = "Birthday", PropertyValueSelector = student => student.Id }
        new Column {Index = 2, Name = "Student Name", PropertyValueSelector = student =>
            String.Format("{0} {1} {2}", student.FirstName, 
                                         student.MiddleName,
                                         student.FamilyName} },
    };
    // I only want 100 youngest students:
    var studentsToDisplay = GetStudents()
        .OrderByDescending(student => student.BirthDay)
        .Take(100)
        .ToList();
    // filling the worksheet is only two lines:
    var worksheet = excelPackage.Workbook.Worksheets.Add("Young Students");
    worksheet.Fill(studentColumns, studentsToDisplay);
