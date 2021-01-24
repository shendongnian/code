cs
public partial class TouchEnabledTextBoxWPF : UserControl
    {
        private Process _touchKeyboardProcess = null;
        public TouchEnabledTextBoxWPF()
        {
            InitializeComponent();
            tbPrincipal.GotTouchCapture += TouchEnabledTextBox_GotTouchCapture;
            tbPrincipal.LostFocus += TouchEnabledTextBox_LostFocus;
        }
        private void TouchEnabledTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_touchKeyboardProcess != null)
            {
                _touchKeyboardProcess.Kill();
                _touchKeyboardProcess = null;
            }
        }
        private void TouchEnabledTextBox_GotTouchCapture(object sender, System.Windows.Input.TouchEventArgs e)
        {
            string touchKeyBoardPath =
                @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";
            _touchKeyboardProcess = Process.Start(touchKeyBoardPath);
        }
    }
Thank you a lot @Clemens!
