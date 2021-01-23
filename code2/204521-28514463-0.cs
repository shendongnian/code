    for (int i = 0; i < 4; i++)
    {
        var state = Joystick.GetState(i);
        if (state.IsConnected)
        {
            float x = state.GetAxis(JoystickAxis.Axis0);
            float y = state.GetAxis(JoystickAxis.Axis1);
                
            // Print the current state of the joystick
            Console.WriteLine(state);
        }
    }
