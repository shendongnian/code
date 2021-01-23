    char[] mySentence = "Pointers in C#".ToCharArray();
    
    fixed (char* start = &mySentence[0])
    {
        char* p = start;
    
        do
        {
            Console.Write(*p);
        }
        while (*(++p) != '\0');
    }
    
    Console.ReadLine();
