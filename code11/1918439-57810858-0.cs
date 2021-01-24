C#
public static int time(int vehicles, int[] specs)
{
    int i, total;
    int[] sums = new int[vehicles];
    Array.Sort(spec);
    sums[0] = specs[0];
    for (i = 1; i < vehicles; i++)
        sums[i] = sums[i - 1] + spec[i];
    total = sums[spec - 1];
}
