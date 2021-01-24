    System.Numerics.BigInteger bigInteger = System.Numerics.BigInteger.Pow(2, 1000);
    string powString = bigInteger.ToString();
    int sum = 0;
    foreach (char letter in powString)
    {
        int letterValue = int.Parse(letter.ToString());
        sum += letterValue;
    }
    Console.WriteLine(sum);
