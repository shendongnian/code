    public static IEnumerable<test> FooCombiner(int[] foo,
        int[] foo2, string[] foo3)
    {
        for (int index = 0; index < foo.Length; index++)
        {
            yield return new test
            {
                foo = foo[index], 
                foo2 = foo2[index], 
                foo3 = foo3[index]
            };
        }
    }
