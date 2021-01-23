    Response.ContentType = "application/pdf";
    IList<Student> students = Student.GetStudents();
    using (Document document = new Document()) {
      PdfWriter writer = PdfWriter.GetInstance(
        document, Response.OutputStream
      );
      document.Open();
      foreach (Student s in students) {
        document.Add(new Paragraph(string.Format(
          "[{0:D8}] - {1}, {2}. MAJOR: {3}",
          s.Id, s.NameLast, s.NameFirst, s.Major
        )));
        List list = new List(List.ORDERED);
        foreach (string c in s.Classes) {
          list.Add(new ListItem(c));
        }
        document.Add(list);
      }
    }
