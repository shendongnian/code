    public enum MessageBoxResult
    {
        None = 0,
        OK,
        Cancel,
        Yes,
        No
    }
    public enum MessageBoxButton
    {
        OK = 0,
        OKCancel,
        YesNo,
        YesNoCancel
    }
    public static class MessageBox
    {
        /* This class emulates Windows style modal boxes. Unfortunately, the original code doesn't work reliably since cca iOS 11.1.2 so 
         * you have to use the asynchronous methods provided here.
         * 
         * The code was a bit restructured utilising class MessageBoxNonstatic to make sure that on repeated use, it doesn't allocate momere memory.
         * Note that event handlers are explicitly removed and at the end I explicitly call garbage collector.
         * 
         * The code is a bit verbose to make it easier to understand and open it to tweaks.
         * 
        */
        // Synchronous methods - don't work well since iOS 11.1.2, often freeze because something has changed in the event loop and
        // NSRunLoop.Current.RunUntil() is not reliable to use anymore
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton buttonType)
        {
            MessageBoxNonstatic box = new MessageBoxNonstatic();
            return box.Show(messageBoxText, caption, buttonType);
        }
        public static MessageBoxResult Show(string messageBoxText)
        {
            return Show(messageBoxText, "", MessageBoxButton.OK);
        }
        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            return Show(messageBoxText, caption, MessageBoxButton.OK);
        }
        // Asynchronous methods - use with await keyword. Restructure the calling code tho accomodate async calling patterns
        // See https://docs.microsoft.com/en-us/dotnet/csharp/async
        /*
         async void DecideOnQuestion()
         {
             if (await MessageBox.ShowAsync("Proceed?", "DECIDE!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
             {
                 // Do something
             }
         }
         */
        public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string caption, MessageBoxButton buttonType)
        {
            MessageBoxNonstatic box = new MessageBoxNonstatic();
            return box.ShowAsync(messageBoxText, caption, buttonType);
        }
        public static Task<MessageBoxResult> ShowAsync(string messageBoxText)
        {
            return ShowAsync(messageBoxText, "", MessageBoxButton.OK);
        }
        public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string caption)
        {
            return ShowAsync(messageBoxText, caption, MessageBoxButton.OK);
        }
    }
    public class MessageBoxNonstatic
    {
        private bool IsDisplayed = false;
        private int buttonClicked = -1;
        private UIAlertView alert = null;
        private string messageBoxText = "";
        private string caption = "";
        private MessageBoxButton button = MessageBoxButton.OK;
        public bool IsAsync = false;
        TaskCompletionSource<MessageBoxResult> tsc = null;
        public MessageBoxNonstatic()
        {
            // Do nothing
        }
        public MessageBoxResult Show(string sMessageBoxText, string sCaption, MessageBoxButton eButtonType)
        {
            messageBoxText = sMessageBoxText;
            caption = sCaption;
            button = eButtonType;
            IsAsync = false;
            ShowAlertBox();
            WaitInLoopWhileDisplayed();
            return GetResult();
        }
        public Task<MessageBoxResult> ShowAsync(string sMessageBoxText, string sCaption, MessageBoxButton eButtonType)
        {
            messageBoxText = sMessageBoxText;
            caption = sCaption;
            button = eButtonType;
            IsAsync = true;
            tsc = new TaskCompletionSource<MessageBoxResult>();
            ShowAlertBox();
            return tsc.Task;
        }
        private void ShowAlertBox()
        {
            IsDisplayed = false;
            buttonClicked = -1;
            alert = null;
            string cancelButton = "Cancel";
            string[] otherButtons = null;
            switch (button)
            {
                case MessageBoxButton.OK:
                    cancelButton = "";
                    otherButtons = new string[1];
                    otherButtons[0] = "OK";
                    break;
                case MessageBoxButton.OKCancel:
                    otherButtons = new string[1];
                    otherButtons[0] = "OK";
                    break;
                case MessageBoxButton.YesNo:
                    cancelButton = "";
                    otherButtons = new string[2];
                    otherButtons[0] = "Yes";
                    otherButtons[1] = "No";
                    break;
                case MessageBoxButton.YesNoCancel:
                    otherButtons = new string[2];
                    otherButtons[0] = "Yes";
                    otherButtons[1] = "No";
                    break;
            }
            IUIAlertViewDelegate d = null;
            if (cancelButton.Length > 0)
                alert = new UIAlertView(caption, messageBoxText, d, cancelButton, otherButtons);
            else
                alert = new UIAlertView(caption, messageBoxText, d, null, otherButtons);
            if (messageBoxText.Contains("\r\n"))
            {
                foreach (UIView v in alert.Subviews)
                {
                    try
                    {
                        UILabel l = (UILabel)v;
                        if (l.Text == messageBoxText)
                        {
                            l.TextAlignment = UITextAlignment.Left;
                        }
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }
            alert.BackgroundColor = UIColor.FromWhiteAlpha(0f, 0.8f);
            alert.Canceled += Canceled_Click;
            alert.Clicked += Clicked_Click;
            alert.Dismissed += Dismissed_Click;
            alert.Show();
            IsDisplayed = true;
        }
        // ======================================================================= Private methods ==========================================================================
        private void WaitInLoopWhileDisplayed()
        {
            while (IsDisplayed)
            {
                NSRunLoop.Current.RunUntil(NSDate.FromTimeIntervalSinceNow(0.2));
            }
        }
        private void Canceled_Click(object sender, EventArgs e)
        {
            buttonClicked = 0;
            IsDisplayed = false;
            DisposeAlert();
        }
        private void Clicked_Click(object sender, UIButtonEventArgs e)
        {
            buttonClicked = (int)e.ButtonIndex;
            IsDisplayed = false;
            DisposeAlert();
        }
        private void Dismissed_Click(object sender, UIButtonEventArgs e)
        {
            if (IsDisplayed)
            {
                buttonClicked = (int)e.ButtonIndex;
                IsDisplayed = false;
                DisposeAlert();
            }
        }
        private void DisposeAlert()
        {
            alert.Canceled -= Canceled_Click;
            alert.Clicked -= Clicked_Click;
            alert.Dismissed -= Dismissed_Click;
            alert.Dispose();
            alert = null;
            GC.Collect();
            if (IsAsync)
                GetResult();
        }
        private MessageBoxResult GetResult()
        {
            MessageBoxResult res = MessageBoxResult.Cancel;
            switch (button)
            {
                case MessageBoxButton.OK:
                    res = MessageBoxResult.OK;
                    break;
                case MessageBoxButton.OKCancel:
                    if (buttonClicked == 1)
                        res = MessageBoxResult.OK;
                    break;
                case MessageBoxButton.YesNo:
                    if (buttonClicked == 0)
                        res = MessageBoxResult.Yes;
                    else
                        res = MessageBoxResult.No;
                    break;
                case MessageBoxButton.YesNoCancel:
                    if (buttonClicked == 1)
                        res = MessageBoxResult.Yes;
                    else if (buttonClicked == 2)
                        res = MessageBoxResult.No;
                    break;
            }
            if (IsAsync)
                tsc.TrySetResult(res);
            return res;
        }
    }
