    using System.Windows;
    using System.Windows.Input;
    namespace Test.Common
    {
        public class Behaviors
        {
            public static readonly DependencyProperty DropFileCommandProperty =
                DependencyProperty.RegisterAttached("DropFileCommand", typeof(ICommand),
                typeof(Behaviors), new FrameworkPropertyMetadata(
                new PropertyChangedCallback(DropFileCommandChanged)));
    
            private static void DropFileCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                FrameworkElement element = (FrameworkElement)d;
    
                element.Drop += Element_DropFile;
            }
    
            private static void Element_DropFile(object sender, DragEventArgs e)
            {
                FrameworkElement element = (FrameworkElement)sender;
    
                ICommand command = GeDropFileCommand(element);
    
                command.Execute(e);
            }
    
    
            public static void SetDropFileCommand(UIElement element, ICommand value)
            {
                element.SetValue(DropFileCommandProperty, value);
            }
    
            public static ICommand GeDropFileCommand(UIElement element)
            {
                return (ICommand)element.GetValue(DropFileCommandProperty);
            }
        }
    }
