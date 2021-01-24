    int[] password = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    Random r = new Random();
    for (int i = 0; i < 3; i++)
    {
        int inputPassword = r.Next(password.Length);
        Console.WriteLine(inputPassword);
    }
