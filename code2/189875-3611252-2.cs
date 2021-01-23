    static void Main(string[] args)
    {
        int x = 10, y = 10;
        bool isFound = false;
        // Rest of the body
        for(int i=0;i<x;i++)
        {
            for(int j=0;j<y;j++)
            {
                if(cautat.Equals(myArrayTable[i,j]))
                {
                    isFound = true;
                    break;
                }
            }
            
            if(isFound)
                break;
        }
        if(isFound)
            Console.WriteLine("Numarul a fost gasit");
        else
            Console.WriteLine("Numarul nu a fost gasit!");
        Console.ReadKey();
    }
