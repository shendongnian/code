public static char GetLetterGrade(double average)
{
    if (average >= 90)
    {
        return 'A';
    }
    else if (average >= 80)
    {
        return 'B';
    }
    else if (average >= 70)
    {
        return 'C';
    }
    else if (average >= 60)
    {
        return 'D';
    }
    return 'E';
}
but if you wish to use `GetLetterGrade(int average)` overload, use it like this
double average = gradesList.Average();
var grade = GetLetterGrade((int)average);
