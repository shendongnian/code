    int[] Ms = new int[] { 10, 11, 12, 13 };
    int N = 42;
    System.Numerics.BigInteger x = new System.Numerics.BigInteger();
    System.Numerics.BigInteger power = 1;
    // composing the pack:
    foreach (int s in Ms) {
        x += power * s;
        power *= N;
    }
    // reading the pack:
    //  extracting i'th number:
    int i = 2;
    power = System.Numerics.BigInteger.Pow(N, i);
    int result = (int)((x / power) % N);
