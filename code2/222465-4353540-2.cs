    using System;
    using System.Windows.Forms;
    
    namespace HideMainWinForm
    {
      public partial class Form1 : Form
      {
        // Initially the main form cannot show
        private bool _canShow = false; 
    
        public Form1()
        {
          InitializeComponent();
    
          Form2 frm = new Form2();
          frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
          frm.Show();      
        }
    
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
          // Once Form2 is closed we now allow the main form to
          // become visible.
          _canShow = true;
          this.Show();
        }
    
        protected override void SetVisibleCore(bool value)
        {
          base.SetVisibleCore(_canShow && value);
        }
      }
    }
