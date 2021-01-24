    control.IsPressed;   // bool, is currently pressed
    
    control.WasPressed;  // bool, pressed since previous tick
    
    control.WasReleased; // bool, released since previous tick
    
    control.HasChanged;  // bool, has changed since previous tick
    
    control.State;       // bool, is currently pressed (same as IsPressed)
    
    control.Value;       // float, in range -1..1 for axes, 0..1 for buttons / triggers
    
    control.LastState;   // bool, previous tick state
    
    control.LastValue;   // float, previous tick value
