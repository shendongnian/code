    public class DetectCapsLockBehavior : Behavior<PasswordBox>
    {
        private int _lastKey;
        private ModifierKeys _modifiers;
    
        [Category("Settings")]
        public bool CapsLockOn
        {
            get { return (bool)GetValue(CapsLockOnProperty); }
            set { SetValue(CapsLockOnProperty, value); }
        }
    
        public static readonly DependencyProperty CapsLockOnProperty = DependencyProperty.Register("CapsLockOn", typeof(bool), typeof(DetectCapsLockBehavior), new PropertyMetadata(null));
    
        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += new RoutedEventHandler(AssociatedObject_PasswordChanged);
            AssociatedObject.KeyDown += new KeyEventHandler(AssociatedObject_KeyDown);
        }
    
        void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            _lastKey = e.PlatformKeyCode;
            _modifiers = Keyboard.Modifiers;
        }
    
        void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (_lastKey >= 0x41 && _lastKey <= 0x5a)
            {
                var lastChar = AssociatedObject.Password.Last();
                if (_modifiers != ModifierKeys.Shift)
                {
                    CapsLockOn = char.ToLower(lastChar) != lastChar;
                }
                else
                {
                    CapsLockOn = char.ToUpper(lastChar) != lastChar;
                }
            }
        }
    }
