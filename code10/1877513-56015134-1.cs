    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public override string ToString()
        {
            return $"StudentID={StudentID} StudentName={StudentName}";
        }
    }
    foreach (var student in removedList2)
    {
        Console.WriteLine(student);
    }
    // StudentID=4 StudentName=Ram
    // StudentID=5 StudentName=Ron
