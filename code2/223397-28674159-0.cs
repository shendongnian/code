        using System;
        using System.Windows;
        using System.Windows.Controls;
    
        public class DialogButtonManager
        {
            public static readonly DependencyProperty IsAcceptButtonProperty = DependencyProperty.RegisterAttached("IsAcceptButton", typeof(bool), typeof(DialogButtonManager), new FrameworkPropertyMetadata(OnIsAcceptButtonPropertyChanged));
            public static readonly DependencyProperty IsCancelButtonProperty = DependencyProperty.RegisterAttached("IsCancelButton", typeof(bool), typeof(DialogButtonManager), new FrameworkPropertyMetadata(OnIsCancelButtonPropertyChanged));
    
            public static void SetIsAcceptButton(UIElement element, bool value)
            {
                element.SetValue(IsAcceptButtonProperty, value);
            }
            
            public static bool GetIsAcceptButton(UIElement element)
            {
                return (bool)element.GetValue(IsAcceptButtonProperty);
            }
    
            public static void SetIsCancelButton(UIElement element, bool value)
            {
                element.SetValue(IsCancelButtonProperty, value);
            }
    
            public static bool GetIsCancelButton(UIElement element)
            {
                return (bool)element.GetValue(IsCancelButtonProperty);
            }
    
            private static void OnIsAcceptButtonPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Button button = sender as Button;
    
                if (button != null)
                {
                    if ((bool)e.NewValue)
                    {
                        SetAcceptButton(button);
                    }
                    else
                    {
                        ResetAcceptButton(button);
                    }
                }
            }
    
            private static void OnIsCancelButtonPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Button button = sender as Button;
    
                if (button != null)
                {
                    if ((bool)e.NewValue)
                    {
                        SetCancelButton(button);
                    }
                    else
                    {
                        ResetCancelButton(button);
                    }
                }
            }
    
            private static void SetAcceptButton(Button button)
            {
                Window window = Window.GetWindow(button);
                button.Command = new RelayCommand(new Action<object>(ExecuteAccept));
                button.CommandParameter = window;
            }
    
            private static void ResetAcceptButton(Button button)
            {
                button.Command = null;
                button.CommandParameter = null;
            }
    
            private static void ExecuteAccept(object buttonWindow)
            {
                Window window = (Window)buttonWindow;
    
                window.DialogResult = true;
            }
    
            private static void SetCancelButton(Button button)
            {
                Window window = Window.GetWindow(button);
                button.Command = new RelayCommand(new Action<object>(ExecuteCancel));
                button.CommandParameter = window;
            }
    
            private static void ResetCancelButton(Button button)
            {
                button.Command = null;
                button.CommandParameter = null;
            }
    
            private static void ExecuteCancel(object buttonWindow)
            {
                Window window = (Window)buttonWindow;
    
                window.DialogResult = false;
            }
        }
