    var writer = new WaveFileWriter("dump.wav", ieeeToPcm.WaveFormat);
    while (ieeeToPcm.Read(arr, 0, arr.Length) > 0)
    {
        if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Escape)
            break;
        buffStream.Write(arr, 0, arr.Length);
        writer.Write(arr, 0, arr.Length);
    }
