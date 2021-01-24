`csharp
namespace Code
{
    public class Program
    {
        public void Start() 
        {
            // Do something
        }
    }
}
`
Then go to the other project, right click > Add > Reference > select your project containing the code above (assuming your using Visual Studio IDE). After, you can access the public functions and properties:
`csharp
using Code;
namespace Visualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Program p = new Program();
            p.Start();
        }
    }
}
`
If you are worried about security, then ensure that `public` functions and properties you deem are safe to expose to other projects. For example, what we just did to use the `Start` function, any other project or some 3rd party program could do also. The only difference is that a reference would be made to the project's .dll produced instead of the project itself. 
A basic rule of thumb (at least for me) is that if there are anything I don't want to expose, then don't make them `public` and have a public function that can be called to perform different actions. This way I can limit what actions and information can be performed or accessed:
`csharp
//within some project
namespace Code
{
    public class Program
    {
        // can't be access from another project directly
        private string _privateText { get;set; }
        
        // can be accessed directly
        public string PublicText { get;set; }
        public void Start() 
        {
            // Do something
        }
        public string getPrivateText() 
        {
            // here you can limit what actions are done and what information to return
            return _privateText;
        }
    }
}
`
You can then do the following:
`csharp
// within another project
using Code;
namespace Visualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Program p = new Program();
            string s1 = p.getPrivateText();
            string s2 = p.PublicText;
            p.Start();
        }
    }
}
`
Hope this helps!
