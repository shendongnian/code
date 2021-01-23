    public delegate void InputHandler(Object sender, InputHandlerEventArgs e);
    public class InputHandlerEventArgs : EventArgs
    {
        public InputManager Input { get; set; }
        public InputHandlerEventArgs(InputManager input)
        {
            Input = input;
        }
    }
    public class UIElement
    {
        //public InputHandler ClickHandler;
        public event InputHandler ClickHandler; // Should be an event
        private int variableIWantToUse;
        protected void OnClickHandler(InputHandlerEventArgs e)
        {
            InputHandler temp = ClickHandler;
            if (temp != null)
            {
                temp(this, e);
            }
        }
    }
    public class UIManager
    {
        private UIElement ui;
        public void AttachClickHandler()
        {
            //ui.ClickHandler = BasicClickAction;
            ui.ClickHandler += BasicClickAction; // Making this an event changes this line of code
        }
        private void BasicClickAction(Object sender, InputHandlerEventArgs e)
        {
            UIElement element = (UIElement)sender;
            // Can I refer to any of UIElement's variables in here?
        }
    }
