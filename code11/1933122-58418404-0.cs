    public static void JoinData(params Expression<Func<Role, object>>[] joins)
    {
        foreach (var join in joins) {
            Console.WriteLine(join);
        }
        Console.ReadKey();
    }
