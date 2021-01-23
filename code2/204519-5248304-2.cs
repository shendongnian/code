            JoystickState state = new JoystickState();
            if (pad.Poll().IsFailure)
            {
                result.Disconnect = true;
                return result;
            }
            if (pad.GetCurrentState(ref state).IsFailure)
            {
                result.Disconnect = true;
                return result;
            }
            result.X = state.X / 5000.0f;
            result.Y = state.Y / 5000.0f;
            int ispressed = 0;
            bool[] buttons = state.GetButtons();
