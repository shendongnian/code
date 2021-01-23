    byte[] b = new byte[100];
    int k = s.Receive(b);
    Console.WriteLine("Recieved...");
    using (var sw = new StreamWriter("output.txt"))
    {
        for (int i = 0; i < k; i++)
        {
            Console.Write(Convert.ToChar(b[i]));
            sw.WriteLine(Convert.ToChar(b[i]));
        }
    }
