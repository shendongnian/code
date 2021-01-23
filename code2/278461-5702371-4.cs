    public partial class Form1 : Form
    {
       private UserControl1 customDropDown;
    
       public Form1()
       {
          InitializeComponent();
    
          // Create the user control
          customDropDown = new UserControl1();
    
          // Add it to the form's Controls collection
          Controls.Add(customDropDown);
          customDropDown.Hide();
       }
    
       private void button1_Click(object sender, EventArgs e)
       {         
          // Display the user control
          customDropDown.Show();
          customDropDown.BringToFront();   // display in front of other controls
          customDropDown.Select();         // make sure it gets the focus
       }
    }
