      public partial class Form1 : Form
      {
        private void Form1_Load(object sender, EventArgs e)
        {
          // The following does not need to happen in the Load of this form
    
          // Create hidden Form
          Form2 frm = new Form2();
    
          // Attach hidden form to this form
          frm.AttachTo(this);
        }
      }
    
      public class Form2 : Form
      {
        public void AttachTo(Form frmMain)
        {      
          frmMain.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
        }
    
        void  frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
          this.Close();
        }
      }
    
