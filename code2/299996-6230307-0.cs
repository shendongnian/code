    public class MyForm : Form
    {
       public MyForm()
       {
          this.Load += AfterEverythingElseLoaded;
       }
    
       private void AfterEverythingElseLoaded(object sender, EventArgs e)
       {
          // Do my own things here...
       }
    }
