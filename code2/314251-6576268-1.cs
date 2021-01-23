    A objectA;
    B objectB = new B();
    C objectC = new C();
    
    Console.WriteLine(objectB.Hello(null)); // 2
    Console.WriteLine(objectC.Hello()); // 3
    
    objectA = objectB;
    
    Console.WriteLine(objectA.Hello()); // 1
    
    objectA = objectC;
    
    Console.WriteLine(objectA.Hello()); // 3
