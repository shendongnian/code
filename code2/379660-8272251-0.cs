        public Form1()
        {
            InitializeComponent();
            CustomToolTip tip = new CustomToolTip();
            tip.SetToolTip(button1, "text");
            tip.SetToolTip(button2, "writing");
            button1.Tag = Properties.Resources.pelican; // pull image from the resources file
            button2.Tag = Properties.Resources.pelican2;       
        }
    }
    class CustomToolTip : ToolTip
    {
        public CustomToolTip()
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw +=new DrawToolTipEventHandler(this.OnDraw);
        }
        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            e.ToolTipSize = new Size(600, 1000);
        }
        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this to customzie the tool tip
        {
            Graphics g = e.Graphics;
            // to set the tag for each button or object
            Control parent = e.AssociatedControl;
            Image pelican = parent.Tag as Image;
            //create your own custom brush to fill the background with the image
            TextureBrush b = new TextureBrush(new Bitmap(pelican));// get the image from Tag
            
            g.FillRectangle(b, e.Bounds);
            b.Dispose();
        }
    }
}
