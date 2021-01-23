    // As written in source
    Console.WriteLine((double)(float)0.6);
    Console.WriteLine((double)0.6f);
    Console.WriteLine((double)(6/10f));
    Console.WriteLine((double)(float)(6/10f));
    // Code as seen by Reflector
    Console.WriteLine((double) 0.60000002384185791);
    Console.WriteLine((double) 0.60000002384185791);
    Console.WriteLine((double) 0.6);
    Console.WriteLine((double) 0.6);
