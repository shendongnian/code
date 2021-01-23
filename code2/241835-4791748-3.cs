    public partial class TestForm : Form
        {
            public TestForm()
            {
                InitializeComponent();
            }      
    
            public void HandleOnButtonClick(Object sender, EventArgs e)
            {
                Button button = sender as Button;
    
                if (button != null)
                    this.Tag = button.Tag;
            }
        }
