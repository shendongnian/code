    using Microsoft.Toolkit.Win32.UI.Controls.WinForms;
    
    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
    
        // Initialize WebView and add it to the Window's controls
        var wvc = new WebView();
        ((ISupportInitialize)wvc).BeginInit();
        wvc.Dock = DockStyle.Fill;
        Controls.Add(wvc);
        ((ISupportInitialize)wvc).EndInit();
    
        // You can also use the Source property
        wvc.Navigate(new Uri("https://www.microsoft.com"));
      }
    }
