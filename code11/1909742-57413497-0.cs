    public void AddPassenger()
    {
          if(passengerCount > passenger.Length - 1)
          {
              Console.WriteLine("Bus is full");
              return;
          }
          Console.WriteLine("how old is the passenger?");
          [passengerCount] = int.Parse(Console.ReadLine());
          passengerCount ++;
    }
