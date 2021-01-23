    byte[] b = new byte[100];
    int k = s.Receive(b);
    Console.WriteLine("Recieved...");
    using (var txt = File.OpenWrite("output.txt"))
    {
        for (int i = 0; i < k; i++)
        {
            Console.Write(Convert.ToChar(b[i]));
            txt.WriteLine(Convert.ToChar(b[i]));
        }
    }
