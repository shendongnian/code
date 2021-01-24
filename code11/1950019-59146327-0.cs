using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var thumb = new Thumb
            {
                Width = 100, 
                Height = 50, 
                Background = new SolidColorBrush(Colors.Red), 
                Foreground = new SolidColorBrush(Colors.White), 
                Template = GetThumbTemplate("")
            };
            Canvas.SetLeft(thumb, 100);
            Canvas.SetTop(thumb, 100);
            
            RootCanvas.Children.Add(thumb);
            thumb.Template = GetThumbTemplate("Hello world!");
        }
        private ControlTemplate GetThumbTemplate(string text)
        {
            var template = "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" TargetType=\"Thumb\">" +
                           "<Border Background=\"{TemplateBinding Background}\">" +
                           "<TextBlock VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\" Text=\"" + text + "\" />" +
                           "</Border>" +
                           "</ControlTemplate>";
            return XamlReader.Parse(template) as ControlTemplate;
        }
    }
}
When I create the `Thumb` I set the `Template` with `GetThumbTemplate` and pass in an empty string. `GetThumbTemplate` creates a simple `ControlTemplate` with a `Border` and a `TextBlock`. I then parse the XAML and return it.
After I add it to the `Canvas`, I update the `Template` of the `Thumb` using the `GetThumbTemplate` method, passing in the string I want to display.
I hope this helps!
