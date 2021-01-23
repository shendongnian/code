    public partial MyUserControl:Control
    {
       public event EventHandler ButtonClicked;
       private void myButtonClick(object sender, EventArgs e)
       {
          if (this.ButtonClicked != null)
             this.ButtonClicked(this, EventArgs.Empty);
       }
    }
    
    public partial MyForm:Form
    {
       private void MethodWhereYouAddTheUserControl()
       {
           var myUC = new MyUserControl();
           myUC += myUC_ButtonClicked;
           // code where you add myUC to the form...
       }
    
       void myUC_ButtonClicked(object sender, EventArgs e)
       {
          // called when the button is clicked
       }
    }
