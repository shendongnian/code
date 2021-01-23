    public void FactMethodName2()
    {
        var s = Stopwatch.StartNew();
        var color1 = new Color(); // This is a structs, so I can define they out of loop and gain some performance
        var color2 = new Color(); 
        for (int i = 0; i < 100000000; i++)
        {
            color1.Raw = i;
            color2.Raw = 100000000 - i;
            int compute = ComputeColorDeltaOptimized(color1, color2);
        }
        Console.WriteLine(s.ElapsedMilliseconds); //5393 vs 7472 of original 
        Console.ReadLine();
    }
