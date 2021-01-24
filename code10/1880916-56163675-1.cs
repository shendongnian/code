    var ints = new int[] { 2, 4, 1, 10, 3, 7 };
    
    var x = ints
        .Where(c => c / 3 > 0) // (4,10,3,7)
        .Select(s2 => s2 + 1)  // (5,11,4,8)
        .Sum();                // 28
