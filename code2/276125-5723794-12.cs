    public class ButtonActivityControl : Control, ISupportInitialize
    {
        [Editor(typeof(ReferencesCollectionEditor), typeof(UITypeEditor))]
        public Button[] Buttons { get; set; }
    
        Dictionary<Button, bool> map = new Dictionary<Button, bool>();
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
            if (this.Site != null) return; // this code is needed otherwise designer crashes when closing
            int h = e.ClipRectangle.Height / this.Buttons.Length;
            int top = 0;
            foreach (var button in this.Buttons)
            {
                e.Graphics.FillRectangle(map[button] ? Brushes.Black : Brushes.White, new Rectangle(0, top, e.ClipRectangle.Width, h));
                top += h;
            }
            base.OnPaint(e);
        }
    
        void ISupportInitialize.BeginInit()
        {
        }
    
        void ISupportInitialize.EndInit()
        {
            if (this.Site != null) return; // this is needed so that designer does not change the colors of the buttons in design-time
            foreach (var button in this.Buttons)
            {
                button.Click += new EventHandler(button_Click);
                button.ForeColor = Color.Blue;
                map[button] = false;
            }
        }
    
        void button_Click(object sender, EventArgs e)
        {
            map[(Button)sender] = !map[(Button)sender];
            this.Invalidate();
        }
    }
