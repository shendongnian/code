    public interface IWindow
     {
         string SomeWindowActivity();
     }
    
     public class MyUserControl
     {
         public IWindow Window { get; set; }
    
         public void SomeActionOnUserControl()
         {
             string data = Window.SomeWindowActivity();
         }
     }
    
     public class MainWindow : IWindow
     {
         MyUserControl MyUserControl { get; set; }
    
         public MainWindow()
         {
             // Link the UserControl to the Window it's one. This can be done trough the 
             // constructor or a property
             MyUserControl.Window = this;
         }
    
         public string SomeWindowActivity()
         {
             // Some code...
    
             return "result";
         }
     }
