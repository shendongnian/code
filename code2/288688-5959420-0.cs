     public class ImagePanel:Panel
    {
        private Image image;
        public Image Image
        {
            get { return image; }
            set
            {
                
                image = value;
                Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if(Image!=null)
            {
                e.Graphics.DrawImage(this.Image,Point.Empty);
            }
            base.OnPaint(e);
        }
    }
