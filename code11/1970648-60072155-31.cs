    Console.WriteLine(string.Join(", ", 
      new int[] { 3, 3, 3, 3, 1, 3, 2 })); 
    // We have 2 dice with 3 faces each;
    // We want to explain 3, 3, 3, 3, 1, 3, 2 sequence
    Console.WriteLine(string.Join(", ", Explosions(
      new int[] { 3, 3, 3, 3, 1, 3, 2 }, 3, 2)));
    Console.WriteLine();
    Console.Write(Explain(new int[] { 3, 3, 3, 3, 1, 3, 2 }, 3, 2));
