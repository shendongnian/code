    using System.Windows.Forms;
    
    //WindowScrape
    using WindowScrape.Types;
    
    namespace WindowsFormsTestApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var npad = HwndObject.GetWindowByTitle("Untitled - Notepad");
            }
        }
    }
