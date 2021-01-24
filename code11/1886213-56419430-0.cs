C#
public double WeekendAverage(int[] saturday, int[] sunday)
{
    double sum = saturday.Sum() + sunday.Sum();
    return sum / (saturday.Length + sunday.Length);
}
