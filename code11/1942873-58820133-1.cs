    public void SoundHorn()
    {
        PerformOperation(car => car.Horn(1000));
    }
    
    public void TurnOnHazardLights()
    {
        PerformOperation(car => car.ToggleHazards(true));
    }
