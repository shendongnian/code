    public int [] passenger = new int[25];
    int freeSeat = 0;
    public void add_passenger()
    {
        if (freeSeat >= 25)
        {
            Console.WriteLine("Sorry, the bus is full");                
            return;
        }
        Console.WriteLine("how old is the passenger?");
        passenger[freeSeat++] = int.Parse(Console.ReadLine()); 
    }
