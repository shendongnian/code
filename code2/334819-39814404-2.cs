    using Xunit;
    [Fact]
    public static void IOTest() {
        bool isExecuted1 = false;
        bool isExecuted2 = false;
        bool isExecuted3 = false;
        bool isExecuted4 = false;
        IO<int> one = new IO<int>( () => { isExecuted1 = true; return 1; });
        IO<int> two = new IO<int>( () => { isExecuted2 = true; return 2; });
        Func<int, IO<int>> addOne = x => { isExecuted3 = true; return (x + 1).ToIO(); };
        Func<int, Func<int, IO<int>>> add = x => y => { isExecuted4 = true; return (x + y).ToIO(); };
        var query1 = ( from x in one
                       from y in two
                       from z in addOne(y)
                       from _ in "abc".ToIO()
                       let addOne2 = add(x)
                       select addOne2(z)
                     );
        Assert.False(isExecuted1); // Laziness.
        Assert.False(isExecuted2); // Laziness.
        Assert.False(isExecuted3); // Laziness.
        Assert.False(isExecuted4); // Laziness.
        int lhs = 1 + 2 + 1;
        int rhs = query1.Invoke().Invoke();
        Assert.Equal(lhs, rhs); // Execution.
        Assert.True(isExecuted1);
        Assert.True(isExecuted2);
        Assert.True(isExecuted3);
        Assert.True(isExecuted4);
    }
