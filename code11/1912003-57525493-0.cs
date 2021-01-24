    var col0_elements = new string[] { "a0", "b0", "c0", "d0", "e0", "f0", "g0", "h0", };
    var col1_elements = new string[] { "a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1", };
    var col2_elements = new string[] { "a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2", };
    IList<string[]> all_elements = new List<string[]>{ col0_elements, col1_elements, col2_elements };
    for (int i = 0; i < col0_elements.Length; i++) // Row iteration
    {
        foreach (var cell in all_elements) // Cell iteration
        {
            Console.Write(cell[i]);   
        }
        Console.WriteLine();
    }
