    var repeats = 50;
    Console.WriteLine();
    Console.WriteLine("byte[][3]");
    //Create lookup table
    var lookups = 1200;
    var Lookup = new byte[lookups][];
    for (int i = 0; i < lookups; i++) {
        byte bValue = (byte)i;
        var b = new byte[3] { bValue, bValue, bValue };
        Lookup[i] = b;
    }
    //Make proto temp readings
    int[] temps = new int[640 * 512];
    Random r = new Random();
    for (int i = 0; i < 640 * 512; i++) {
        temps[i] = r.Next(0, 255);
    }
    int size = 640 * 512 * 3;
    byte[] imageValues = new byte[size];
    long totalMS = 0;
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < repeats; i++) {
        sw.Restart();
        int index = 0;
        foreach (int item in temps) {
            if (item < lookups) {
                var pixel = Lookup[item];
                imageValues[index] = pixel[0];
                imageValues[index + 1] = pixel[1];
                imageValues[index + 2] = pixel[2];
                index += 3;
            }
        }
        sw.Stop();
        totalMS += sw.ElapsedMilliseconds;
        //Console.WriteLine(sw.ElapsedMilliseconds);
    }
    Console.WriteLine($"Average: {totalMS / (double)repeats} ms");
