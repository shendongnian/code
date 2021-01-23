    var buttonStates = new [] {
         mouseEventArgs.LeftButton, 
         mouseEventArgs.MiddleButton,
         mouseEventArgs.RightButton,
         mouseEventArgs.XButton1,
         mouseEventArgs.XButton2};
    if (buttonStates.All(s => s == MouseButtonState.Released))
    {
         return;
    }
