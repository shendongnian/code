    var p = new DynamicParameters();
    p.AddDynamicParams(new{a = "1"});
    p.AddDynamicParams(new{b = "2", c = "3"});
    p.Add("d", "4")
    var r = cnn.Query("select @a a, @b b, @c c, @d d", p);
    // r.a == 1, r.b == 2, r.c == 3, r.d == 4
