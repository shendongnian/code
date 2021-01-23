    public partial class MessageBoxForm : Form
    {
      public MessageBoxForm()
      {
        InitializeComponent();
      }
      private void MessageBoxForm_Load(object sender, EventArgs e)
      {
        if (Customers != null) 
        {
          // add your code here to add your Customers as needed
        }
      }
      public Customers Customers { get; set; }
    }
