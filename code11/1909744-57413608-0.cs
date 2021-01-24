    public void add_passenger()
    {
        var oldPassengers = passenger;
        // you might want to restrict the growth to 25
        passenger = new int[passenger.Length + 1];
        Array.Copy(oldPassengers, passenger, olsPassengers.Length);
        
        Console.WriteLine("how old is the passenger?");
        passenger[passenger.Length - 1] = int.Parse(Console.ReadLine()); 
    }
