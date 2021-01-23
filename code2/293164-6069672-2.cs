    public void TestDbString()
    {
        var obj = connection.Query("select datalength(@a) as a, datalength(@b) as b, datalength(@c) as c, datalength(@d) as d, datalength(@e) as e, datalength(@f) as f",
            new
            {
                a = new DbString { Value = "abcde", IsFixedLength = true, Length = 10, IsAnsi = true },
                b = new DbString { Value = "abcde", IsFixedLength = true, Length = 10, IsAnsi = false },
                c = new DbString { Value = "abcde", IsFixedLength = false, Length = 10, IsAnsi = true },
                d = new DbString { Value = "abcde", IsFixedLength = false, Length = 10, IsAnsi = false },
                e = new DbString { Value = "abcde", IsAnsi = true },
                f = new DbString { Value = "abcde", IsAnsi = false },
            }).First();
        ((int)obj.a).IsEqualTo(10);
        ((int)obj.b).IsEqualTo(20);
        ((int)obj.c).IsEqualTo(5);
        ((int)obj.d).IsEqualTo(10);
        ((int)obj.e).IsEqualTo(5);
        ((int)obj.f).IsEqualTo(10);
    }
