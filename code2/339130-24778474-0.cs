    int x = 5, y = 10, answer;
    double ansDouble;
    answer = (int)(x / y) * 100; //percentage calculation
    Console.WriteLine("percentage={0}", answer);
    //>output percentage=0
    answer = (int)((double)x / y) * 100; //percentage calculation
    Console.WriteLine("percentage={0}", answer);
    //>output percentage=0
    answer = (int)((double)x / (double)y) * 100; //percentage calculation
    Console.WriteLine("x={0}", answer);
    //>output percentage=0
    answer = (int)(x/(double)y) * 100; //percentage calculation
    Console.WriteLine("x={0}", answer);
    //>output percentage=0
    ansDouble = ((double)x / y) * 100;
    answer = (int)ansDouble;
    Console.WriteLine("percentage={0}", answer);
    //>output percentage=50
