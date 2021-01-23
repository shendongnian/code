    public partial class MyMdiForm : Form
    {
        public MyMdiForm()
        {
            InitializeComponent();
            foreach (Control control in Controls)
            {
                if (control is MdiClient)
                    control.Paint += mdiBackgroundPaint;
            }
        }
        private void mdiBackgroundPaint(object sender, PaintEventArgs e)
        {
            var mdi = sender as MdiClient;
            if (mdi == null) return;
            e.Graphics.Clip = new System.Drawing.Region(mdi.ClientRectangle);
            e.Graphics.DrawString("*** YOUR NAME HERE ***",this.Font,Brushes.Red,100F,100F);
        }
    }
