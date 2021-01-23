    using System;
    using System.Drawing;
    using MonoTouch.UIKit;
    using MonoTouch.Foundation;
    using System.Collections.Generic;
    
    namespace YourNameSpace
    {
    
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
            public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton buttonType)
            {
                MessageBoxResult res = MessageBoxResult.Cancel;
                bool IsDisplayed = false;
                int buttonClicked = -1;
                MessageBoxButton button = buttonType;
                UIAlertView alert = null;
    
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
    
                if (cancelButton.Length > 0)
                    alert = new UIAlertView(caption, messageBoxText, null, cancelButton, otherButtons);
                else
                    alert = new UIAlertView(caption, messageBoxText, null, null, otherButtons);
    
                alert.BackgroundColor = UIColor.FromWhiteAlpha(0f, 0.8f);
                alert.Canceled += (sender, e) => {
                    buttonClicked = 0;
                    IsDisplayed = false;
                };
    
                alert.Clicked += (sender, e) => {
                    buttonClicked = e.ButtonIndex;
                    IsDisplayed = false;
                };
    
                alert.Dismissed += (sender, e) => {
                    if (IsDisplayed)
                    {
                        buttonClicked = e.ButtonIndex;
                        IsDisplayed = false;
                    }
                };
    
                alert.Show();
    
                IsDisplayed = true;
    
                while (IsDisplayed)
                {
                    NSRunLoop.Current.RunUntil (NSDate.FromTimeIntervalSinceNow (0.2));
                }
    
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
    
                return res;
            }
    
            public static MessageBoxResult Show(string messageBoxText)
            {
                return Show(messageBoxText, "", MessageBoxButton.OK);
            }
    
            public static MessageBoxResult Show(string messageBoxText, string caption)
            {
                return Show(messageBoxText, caption, MessageBoxButton.OK);
            }
        }
    }
