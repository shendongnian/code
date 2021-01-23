     namespace WindowsFormsApplication2
    {
     public partial class Pops : Form
     {
      public event PopSaveClickedHandler PopSaveClicked;
      public Pops()
      {
       
       InitializeComponent();
      }
      private void btnSave_Click(object sender, EventArgs e)
      {
      if(PopSaveClicked!=null)
      {
        this.PopSaveClicked(txtUserName.Text);
      }
      }
     }
    }
