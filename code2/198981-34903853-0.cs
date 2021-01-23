	using System.Windows.Controls;
	namespace TestGenericUserControl
	{
		public abstract partial class GenericUserControl : UserControl
		{
			// If you use event handlers in GenericUserControl.xaml, you have to define 
            // them here as abstract and implement them in the generic class below, e.g.:
			
			// abstract protected void MouseClick(object sender, MouseButtonEventArgs e);
		}
		
		public class GenericUserControl<T> : GenericUserControl
		{
			// generic properties and stuff
			
			public GenericUserControl()
			{
				InitializeComponent();
			}
		}
		
		// To use the GenericUserControl<T> in XAML, you could define:
		public class GenericUserControlString : GenericUserControl<string> { }
		// and use it in XAML, e.g.:
		// <GenericUserControlString />
		// alternatively you could probably (not sure) define a markup extension to instantiate
		// it directly in XAML
	}
