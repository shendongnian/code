    WindowsFormsApplication1
    {
         public partial class Form1 : Form
        {
            static Label statusMessageLabel;
            public static string StatusText { set { statusMessageLabel.Text = value; } }
    
            public Form1()
            {
                InitializeComponent();
                statusMessageLabel = label1;
    
                // from anywhere ->
                Form1.StatusText = "a message";
            }
        }
    
    }
