    Decimal[] decimals = { new Decimal(2.85), new Decimal(2), new Decimal(1.99) };
    foreach (var x in decimals)
    {
      Console.WriteLine(string.Format("{0:0.#}", Decimal.Truncate(x * 10) / 10));
    }
    // output
    2.8
    2
    1.9
