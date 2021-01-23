    public partial class Form1 : Form
    {
    
    public Form1()
    {
        InitializeComponent();
        label1.MouseDown += MyMouseDown;
    }
    
    void MyMouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)//If it's left button that's the trigger
        {
            Control c = (Control)sender;
            if (c.Parent == null) return;//Has no more children, wrong condition?
            if(c.Parent != this)//We've reached top level
            {
                MyMouseDown(c.Parent, new MouseEventArgs(e.Button, 
                     e.Clicks, 
                     c.Parent.Location.X + e.X, 
                     c.Parent.Location.Y + e.Y, 
                     e.Delta));
                return;
             }
             //Do what shall be done here...
         }
    }
    }
