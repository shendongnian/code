c#
static List<Person> students = new List<Person>();
private static void initializeClassroom()
{
    for (int i = 1; i <= 10; i++)
    {
        person student = new person()
        {
            number = i,
            pass= false
        };
        students.Add(student);
    }
}
private static void CheckForPass()
{
    foreach (var student in students)
    {
        if (!student.pass)
        {
            return;
        }
    }
    Console.WriteLine("Congratulations! All members have passed");
    Console.ReadKey();
}
