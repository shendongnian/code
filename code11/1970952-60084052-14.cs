    int foo = 1;
    int[] bar = {foo};
    Console.WriteLine(bar[0]); // 1 -- initialing the value worked
    bar[0] = 2;
    Console.WriteLine(foo); // still 1 -- changing the array doesn't change the variable
    
    foo = 3; 
    Console.WriteLine(bar[0]); // still 2 -- changing the variable doesn't change the array
