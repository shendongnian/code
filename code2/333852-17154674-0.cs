    public static class Refresh 
    
        {
            public static void Refresh_Controls(this UIElement uiElement)
            {
                uiElement.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => { }));
            }
        }
