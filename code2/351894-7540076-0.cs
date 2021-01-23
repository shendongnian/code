    //<Usings>
    namespace Test.Controls
    {
    	public class ImageButton : Button
    	{
    		public static readonly DependencyProperty ImageProperty =
    			DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new UIPropertyMetadata(null));
    		public ImageSource Image
    		{
    			get { return (ImageSource)GetValue(ImageProperty); }
    			set { SetValue(ImageProperty, value); }
    		}
    	}
    }
