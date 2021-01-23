    public class CalcButton : Button
    {
        public delegate void CalcButtonHandler(object sender);
        public event CalcButtonHandler Pressed;
        public event CalcButtonHandler Released;
        private bool hasFocus = false;
        private bool _isPressed = false;
        private bool isPressed
        {
            set
            {
                if (value != _isPressed)
                {
                    _isPressed = value;
                    Debug.WriteLine(Name + (_isPressed ? " Button Is Pressed" : " Button Is Released"));
                    if (_isPressed)
                    {
                        // custom default press action
                        // here
                        if (Pressed != null)
                        {
                            Pressed(this);
                        }
                    }
                    else
                    {
                        if (Released != null)
                        {
                            Released(this);
                        }
                    }
                }
            }
            get
            {
                return _isPressed;
            }
        }
        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine(Name + " is pressed change");
            if (hasFocus && !base.IsPressed)
            {
                isPressed = false;
            }
            else if (base.IsPressed)
            {
                isPressed = true;
            }
            base.OnIsPressedChanged(e);
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            hasFocus = false;
            _isPressed = false; // do not trigger key release event
            Debug.WriteLine(Name + " lost focus");
            base.OnLostFocus(e);
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            hasFocus = true;
            Debug.WriteLine(Name + " got focus");
            base.OnGotFocus(e);
        }
        protected override void OnHold(GestureEventArgs e)
        {
            _isPressed = false; // do not trigger key release event
            Debug.WriteLine(Name + " on hold");
            base.OnHold(e);
        }
    }
