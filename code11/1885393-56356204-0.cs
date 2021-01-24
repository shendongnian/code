    string[][] cubeState = new string[][] {
        new [] { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F" },
        new [] { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E", "F", "F" }
    };
    string[][] newCube = cubeState.Select(x => x.ToArray()).ToArray();
