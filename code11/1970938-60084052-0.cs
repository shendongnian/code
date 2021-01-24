    int foo = 1;
    int[] bar = {foo};
    Console.WriteLine(bar[0]); // 1
    bar[0] = 2;
    Console.WriteLine(foo); // still 1
    
    foo = 3; 
    Console.WriteLine(bar[0]); // still 2
