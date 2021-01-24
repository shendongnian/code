    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        protected override void OnHandleCreated(EventArgs e)
        {
            // Use e.g. Color.FromArgb(128, Color.Lime) for a 50% opacity green tint.
            WindowUtils.EnableAcrylic(this, Color.Transparent);
    
            base.OnHandleCreated(e);
        }
    
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
        }
    }
