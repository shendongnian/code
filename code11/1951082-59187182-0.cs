for (int i = 1; i <= 6; i++)
{
    Console.Write("Enter Student ID:");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter Score for Student " + id + ": ");
    int grade = Convert.ToInt32(Console.ReadLine());
    Score classTwo = new Score(id, grade);
    classOne.addScore(classTwo);
}
