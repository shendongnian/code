    public void StartRace()
    {
        // if both cars exist
        if (NullHelper.Exists(RedCar, WhiteCar))
        {
            // Create a new instance of a 'RandomShuffler' object.
            Shuffler = new RandomShuffler(2, 12, 100, 3);
            // Start the timer on the RedCar
            RedCar.Start();
        }
    }
