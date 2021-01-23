    public partial class Form1 : Form
    {
      // This method connects the event handler.
      public Form1()
      {
        InitializeComponent();
        button1.Click += new EventHandler(X);
      }
    
      // This is the event handling method.
      public int X(int a,int b) { } 
    }
