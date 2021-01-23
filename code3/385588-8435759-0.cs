    const int count = 100000;
    var data = "9D";
    var sw = new Stopwatch();
    sw.Reset();
    byte dest = 0;
    sw.Start();
    for(int i=0; i < count; ++i)
    {
        dest = Byte.Parse(data, NumberStyles.AllowHexSpecifier);
    }
    sw.Stop();
    var parseTime = sw.ElapsedMilliseconds;
    sw.Reset();
    sw.Start();
    for(int i=0; i < count; ++i)
    {
        dest = Convert.ToByte(data, 16);
    }
    sw.Stop();
    var convertTime = sw.ElapsedMilliseconds;
