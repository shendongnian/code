    public class MyForm : Form
    {
      public MyForm()
      {
        InitializeComponenents();
    
        MyButton = new Button { Text = "GO" } ;
        this.Controls.Add(MyButton);
      }
    
      public Button MyButton { get; private set; }
    }
