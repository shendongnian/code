    static void Main(string[] args)
    {
        //Start
        Console.Write("Hit Enter to Start\n");
        Console.ReadLine();
        long num = 100;
        long mil = 0;
        float val = 0.01f;
        Stopwatch startTime = new Stopwatch();
        //Run
        for(long i = 0; i != num; ++i)
        {
            startTime.Restart();
            for(uint i2 = 0; i2 != 1000000; ++i2) val = (float)System.Math.Cos(val);// 48 Milliseconds
            //for(uint i2 = 0; i2 != 1000000; ++i2) val = System.Math.Cos(val).ToFloat();// 53 Milliseconds
            //for(uint i2 = 0; i2 != 1000000; ++i2) val = MathF2.Cos(val);// 59 Milliseconds
            //for(uint i2 = 0; i2 != 1000000; ++i2) val = MathF.Cos(val);// 63 Milliseconds
            startTime.Stop();
            mil += startTime.ElapsedMilliseconds;
        }
        //End
        mil /= num;
        //Print
        Console.Write("Milliseconds = "+mil.ToString());
        Console.ReadLine();
    }
