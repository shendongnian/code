    public class myOwnForm : Form
    {
      public Button myOwnButton;
      public myOwnForm()
      {
        InitializeComponent();
        myOwnButton = new Button();
        myOwnButton.Text = "Click Me!";
        myOwnButton.Size = new Size(50,50);
        myOwnButton.Location = new Point(100,100);
        Controls.Add(myOwnButton);
      }
    }
