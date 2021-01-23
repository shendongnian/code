    public class Presenter
    {
         public void DoStuff() {};
    }
    public MyForm : Form
    {
         private Presenter presenter;
         public MyForm()
         {
            presenter = new Presenter();
         }
         private void OnButtonClick(object sender, EventArgs e)
         {
             presenter.DoStuff();
         }
    }
