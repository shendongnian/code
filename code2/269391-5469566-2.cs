    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace MDITest
    {
      public partial class TooltipForm : Form
      {
        Timer _timer = new Timer();
    
        public TooltipForm()
        {
          InitializeComponent();
          TopLevel = true;
          _timer.Enabled = false;
          _timer.Interval = 5000;
          _timer.Tick += new EventHandler(_timer_Tick);
        }
    
        void _timer_Tick(object sender, EventArgs e)
        {      
          Visible = false;
        }
    
        protected override void SetVisibleCore(bool value)
        {
          if (value == true)
          {
            _timer.Start();
          }
          else
          {
            _timer.Stop();
          }
          base.SetVisibleCore(value);
        }
    
        public Image Image
        {
          get
          {
            return pictureBox1.Image;
          }
          set
          {
            pictureBox1.Image = value;
          }
        }
      }
    }
