    public partial class Form1 : Form 
    { 
      public Form1() 
      { 
        InitializeComponent(); 
      } 
    
      protected override void SetVisibleCore(bool value) 
      {       
        // Quick and dirty to keep the main window invisible
        // you can put some logic here to decide when to use the
        // incomming value and when to force it to be false as I 
        // am showing here.       
        base.SetVisibleCore(false); 
      } 
    } 
