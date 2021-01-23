    byte[] b = new byte[100];
    int k = s.Receive(b);
    Console.WriteLine("Recieved...");
    for (int i = 0; i < k; i++)
    {
        Console.Write(Convert.ToChar(b[i]));
        var myChar = Convert.ToChar(b[i]);
    }
