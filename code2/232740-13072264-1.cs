    byte[] pp = new byte[] { 1, 2, 3, 4 };
    SubArray<byte> sa = new SubArray<byte>(pp, 2, 2);
    
    Console.WriteLine(sa[0]);
    Console.WriteLine(sa[1]);
    //Console.WriteLine(b[2]); exception
    
    Console.WriteLine();
    foreach (byte b in sa) {
    	Console.WriteLine(b);
    }
            
