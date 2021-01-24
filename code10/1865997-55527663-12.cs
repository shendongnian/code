    var ary1 = new int[3,3];
    ary1[0, 0] = 0;
    ary1[0, 1] = 1;
    ary1[0, 2] = 2;
    ary1[1, 0] = 3;
    ary1[1, 1] = 4;
    ary1[1, 2] = 5;
    ary1[2, 0] = 6;
    ary1[2, 1] = 7;
    ary1[2, 2] = 8;
    
    var ary2 = new int[9];
    
    Buffer.BlockCopy(ary1, 0, ary2, 0, 9 * sizeof(int));
    
    Console.WriteLine(string.Join(",", ary2));
