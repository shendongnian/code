    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
          //Attach a handler for the MouseWheel event
          ToolStripComboBox1.ComboBox.MouseWheel += new MouseEventHandler(ToolStripComboBox_MouseWheel);
       }
       private void ToolStripComboBox_MouseWheel(object sender, MouseEventArgs e)
       {
          //Cast the MouseEventArgs to HandledMouseEventArgs
          HandledMouseEventArgs mwe = (HandledMouseEventArgs)e;
          //Indicate that this event was handled
          //(prevents the event from being sent to its parent control)
          mwe.Handled = true;
       }
    }
