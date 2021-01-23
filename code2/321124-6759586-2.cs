    public void HandleUserInput()
    {
        if (MouseButton.WasPressed())
        {
            ((IChargable)weapon).StartCharging();
        }
        else if (MouseButton.WasReleased())
        {
            weapon.Fire();
        }
    }
