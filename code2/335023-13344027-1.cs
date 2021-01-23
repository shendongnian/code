    public partial class LoginWindow : Window
    {
        ...
        private void Window_Activated(object sender, EventArgs e)
        {
            SetCapsLockOnState();
        }
        private Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            SetCapsLockOnState();
        }
        private void SetCapsLockOnState()
        {
            if (Console.CapsLock)
            {
                CapsLockOn.Visibility.Visible;
            }
            else
            {
                CapsLockOn.Visibility.Hidden;
            }
        }
        ...
    }
