    enum MyButtons { ShootButton, JumpButton }
    Dictionary<MyButtons, Buttons> inputMap = new Dictionary<MyButtons, Buttons>()
    {
        { MyButtons.ShootButton, Buttons.Y },
        { MyButtons.JumpButton,  Buttons.B },
    }
    ...
    if (gamePadState.IsButtonDown(inputMap[MyButtons.ShootButton]))
    {
        // Shoot...
    }
