    public void AddPlayer(Character p1, p2, p3, p4, p5, p6, p7, p8, p9, p10)
    {
        characters.Add(p1); // characters has now capacity 4
        characters.Add(p2);
        characters.Add(p3);
        characters.Add(p4);
        characters.Add(p5); // characters reallocated and has now capacity 8 
        characters.Add(p6);
        characters.Add(p7);
        characters.Add(p8);
        characters.Add(p9); // characters reallocated and has now capacity 16
        characters.Add(p10);
    }
