for (int i = 1; i <= 6; i++)
{
    Console.Write("Enter Student ID:");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter Score for Student " + id + ": ");
    int grade = Convert.ToInt32(Console.ReadLine());
    Score classTwo = new Score(id, grade);
    classOne.addScore(classTwo);
}
**EDIT**
If you already have your Student ID's in an array you can loop over that array:
int[] studentIds = new[] { 3524, 4321, 546, 7896, 4327, 123 };
ClassScores classOne = new ClassScores(studentIds.Length);
foreach(int id in studentIds)
{
    Console.Write("Enter Score for Student " + id + ": ");
    int grade = Convert.ToInt32(Console.ReadLine());
    Score classTwo = new Score(id, grade);
    classOne.addScore(classTwo);
}
We have changed the `for` loop to a `foreach` which will loop over each item in the array and retrieve each value
If you still want to use a `for` loop instead then you can use the loop variable to get the ID from the array - remember arrays are zero based so you need to loop from zero to the length of the array:
for (int i = 0; i < studentIds.LEngth; i++)
{
    int id = studentIds[i];
    ...
}
