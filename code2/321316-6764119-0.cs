    static void Variante_2(int height, int width)
    {
      byte[][] arr = new byte[height][];
      int pos = 0;
      int mov = 1;
      for (int line = 0; line < height; line++)
      {
        arr[line] = new byte[width];
        for (int col = 0; col < width; col++) { arr[line][col] = 45; }
        arr[line][pos] = 42;
        pos += mov;
        if (pos == 0 || pos == (width - 1)) { mov *= -1; }
        Console.WriteLine("|" + ASCIIEncoding.ASCII.GetString(arr[line]) + "|");
      }
      string temp = Console.ReadLine();
    }
