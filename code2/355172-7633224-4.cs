    namespace WPFApplication1
    {
        public class MasterWindow : ContentControl
        	{
                public static RoutedCommand CloseWindowCommand;
        
                static MasterWindow()
        		{
                    DefaultStyleKeyProperty.OverrideMetadata(typeof(MasterWindow), new FrameworkPropertyMetadata(typeof(MasterWindow)));
                    CloseWindowCommand = new RoutedCommand("CloseWindow", typeof(MasterWindow));
                    CommandManager.RegisterClassCommandBinding(typeof(MasterWindow), new CommandBinding(CloseWindowCommand, CloseWindowEvent));
        
        		}
        
        
                public static readonly DependencyProperty WindowTitleProperty = DependencyProperty.Register("WindowTitle", typeof(object), typeof(MasterWindow), new UIPropertyMetadata());
        
                public object WindowTitle
        		{
                    get { return (object)GetValue(WindowTitleProperty); }
                    set { SetValue(WindowTitleProperty, value); }
        		}
        
                private static void CloseWindowEvent(object sender, ExecutedRoutedEventArgs e)
                {
                    MasterWindow control = sender as MasterWindow;
                    if (control != null)
                    {
                        Window objWindow = Window.GetWindow(((FrameworkElement)sender));
                        if (objWindow != null)
                        {
                            if (objWindow.Name.ToLower() != "unlockscreenwindow")
                            {
                                Window.GetWindow(((FrameworkElement)sender)).Close();
                            }
                        }
                    }
                }
            }  
    }
