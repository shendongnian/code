    float[] test = new float[10];
    float[] test2 = new float[10];
    test = Enumerable.Range(10, 10).Select(x => (float)x).ToArray();// 10 - 20
    test2 = Enumerable.Range(20, 10).Select(x => (float)x).ToArray();// 20 - 30
    float[] testBak = test;
    test = test2;
    test[0] = 1;
    Console.WriteLine(test[0]);// prints 1 as it was just modified
    Console.WriteLine(test2[0]);// prints 1 because it has the same value of the reference as 'test'
    Console.WriteLine(testBak[0]);// prints 10 which is the old value of test[0]
