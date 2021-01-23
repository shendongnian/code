    int j = 2000;
    var bytes = j.ToByteArray();
    Console.WriteLine(bytes.Length);
    for(int index = 0; index < bytes.Length; index++) {
        Console.WriteLine("{0:x}", bytes[index]);
    }
