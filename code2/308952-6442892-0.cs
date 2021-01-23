    public partial class MyButton : Button, IOnLoad
    {
      void OnLoad() { // call "OnLoadDelegate" }
    }
    
    public partial class MyForm : Form
    {
      
      public void MyForm_Load(...) {
        foreach(Control eachControl in Controls) {
          if (eachControl is IOnLoad) {
            IOnLoad eachOnLoadControl = (IOnLoad)eachControl;
            eachOnLoadControl.OnLoad();
          }
        } // foreach
      }
    } // class
