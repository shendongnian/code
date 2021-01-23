    public partial class BaseForm : Form
    {
      private ChildForm _OtherForm;
    
      public BaseForm()
      {
        InitializeComponent();
      }
    
      private void button1_Click(object sender, EventArgs e)
      {
        if (_OtherForm == null || _OtherForm.IsDisposed)
        {
          _OtherForm = new ChildForm();
          _OtherForm.DisableBase += new ChildForm.DisableBaseHandler(DisableMe);
        }
        _OtherForm.Show();
      }
    
      private void DisableMe(object sender, EventArgs e)
      {
        //Disable Base Controls...
        button1.Enabled = false;
      }
    }
