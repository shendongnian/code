    public class ExampleCustomControl : Control
    {
        public string Title { get; set; } = "";
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public StringCollection SomeValues { get; set; } = new StringCollection();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
           
            // grab the graphics object
            var g = e.Graphics;
            // draw the title property
            g.DrawString(Title, Font, Brushes.Blue, 0, 0);
            // will alter positions
            var y = 10;
            // for each value set in the properties
            foreach (var value in SomeValues)
            {
                // draw the property value
                g.DrawString(value, Font, Brushes.Red, 0, y);
                // move the position for the next text
                y += 10;
            }
        }
    } 
