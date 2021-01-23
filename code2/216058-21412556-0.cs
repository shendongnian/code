    public static List<Student> convertXMLtoList(string filePath)
    {
    XDocument doc = XDocument.Load(filePath);
    List<Student> studentsMarks = doc.Descendants("Student").Select(x => new Student()
    {
    RollNo = int.Parse(x.Element("roll_no").Value),
    Name = x.Element("name").Value,
    }).ToList();
    return studentsMarks;
    } 
