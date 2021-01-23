    int testValue = 160;
    System.Collections.BitArray bitarray = new System.Collections.BitArray(new int[] { testValue });
    var bitList = new List<bool>();
    foreach (bool bit in bitarray)
        bitList.Add(bit);
    bitList.Reverse();
    var base2 = 0;
    foreach (bool bit in bitList)
    {
        base2 *= 10; // Shift one step left
        if (bit)
            base2++; // Add 1 last
    }
    Console.WriteLine(base2);
