    public class FormChild : System.Windows.Forms.Form
    {
        public event EventHandler DialogCanceled;
        public event EventHandler DialogConfirmed;
        public void ShowDialog()
        {
            using (var dialogForm = new   FormDialog())
            {
                if (dialogForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (DialogConfirmed != null)
                        DialogConfirmed(this,new EventArgs());
                }
                else
                {
                    if (DialogCanceled != null)
                        DialogCanceled(this,new EventArgs());
                }
            }
        }
    }
    public class ParentForm : System.Windows.Forms.Form
    {
        public void callChild()
        {
            using (var f = new FormChild())
            {
                f.DialogCanceled += new EventHandler(f_DialogCanceled);
                f.DialogConfirmed += new EventHandler(f_DialogConfirmed);
                f.ShowDialog();
            }
        }
    
        void f_DialogConfirmed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    
        void f_DialogCanceled(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
