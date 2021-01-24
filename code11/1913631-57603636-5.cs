    string x2 = "shark"; // actually = 
    string y2 = x.Substring(1);
    unsafe
    {
       fixed (char* c = y2)
       {
          c[0] = 'p';
       }
    }
    
    Console.WriteLine(x2);
    Console.WriteLine(y2);
