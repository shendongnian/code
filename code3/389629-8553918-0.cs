    static void Main (string[] args)
    {
        foreach (int i in Program.NaturalNumbers ())
        {
            Console.WriteLine (i);
        }
    }
    public static IEnumerable<int> NaturalNumbers ()
    {
        for (int i = 0; i <= int.MaxValue; i++)
        {
            yield return i;
        }
    }
