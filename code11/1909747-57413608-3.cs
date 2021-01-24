    public void add_passenger()
    {
        if (passenger.Length >= 25)
        {
            Console.WriteLine("Sorry, the bus is full");                
            return;
        }
        var oldPassengers = passenger;
        passenger = new int[passenger.Length + 1];
        Array.Copy(oldPassengers, passenger, olsPassengers.Length);
        
        Console.WriteLine("how old is the passenger?");
        passenger[passenger.Length - 1] = int.Parse(Console.ReadLine()); 
    }
