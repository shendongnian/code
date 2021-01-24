	public class ButtonViewModel : DependencyObject
    {
        public static readonly DependencyProperty CommandProperty = 
			DependencyProperty.Register("Command", typeof(ICommand), 
			typeof(ButtonViewModel), new PropertyMetadata(default(ICommand)));
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
	}
		
