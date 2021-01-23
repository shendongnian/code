    byte[] b = new byte[100];
    int k = s.Receive(b);
    Console.WriteLine("Recieved...");
    StringBuilder a = new StringBuilder();
    
    for (int i = 0; i < k; i++)
    {
        a.Append(Convert.ToChar(b[i]);
    }
    string str = a.ToString();
