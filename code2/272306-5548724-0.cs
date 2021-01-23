    public static IEnumerable<test> Test(int[] foo, int[] foo2, string[] foo3)
    {
        // do some length checking
        for (int i = 0; i < foo.Length; i++)
        {
            yield return new test()
            {
                foo = foo[i],
                foo2 = foo2[i],
                foo3 = foo3[i]
            };
        }
    }
