    public partial class TogglingForm : Form
    {
        TogglingForm Other {get; set;}
        public TogglingForm()
        {
            InitializeComponent();
        }        
    
        private void HideOther_Click(object sender, EventArgs e)
        {
            Other.Visible = false;
        }
    
        private void ShowOther_Click(object sender, EventArgs e)
        {
            Other.Visible = true;
        }
    }
    ....
    static void Main()
    {
       var first = new TogglingForm();
       var second = new TogglingForm {Other = first};
       first.Other = second;
      
       first.Show();
    }   
