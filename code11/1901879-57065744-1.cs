    int size = 640 * 512 * 3;
    byte[] imageValues = new byte[size];
    var sw = new Stopwatch();
    byte[] pixel = new byte[3];
    for (int i = 0; i < 50; i++)
    {
        sw.Start();
        int index = 0;
        foreach (var item in temps)
        {
            pixel = array[item * 100];
            imageValues[index] = pixel[0];
            imageValues[index + 1] = pixel[1];
            imageValues[index + 2] = pixel[2];
            index += 3;
         }
    }
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds}/{sw.ElapsedMilliseconds / 50.0}");
    
