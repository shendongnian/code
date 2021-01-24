    public int? [] passenger = new int?[25];
    public void add_passenger()
    {
        for (int i = 0; i < passenger.Length; i++)
        {   
            if (passenger[i] is null)
            {
                Console.WriteLine("how old is the passenger?");
                passenger[i] = int.Parse(Console.ReadLine()); 
                return;
            }                
        }
        Console.WriteLine("Sorry, the bus is full");                
    }
