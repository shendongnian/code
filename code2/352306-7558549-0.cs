    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.AllowDrop = true;
            this.pictureBox1.MouseDown += pictureBox1_MouseDown;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                var dragImage = (Bitmap)pictureBox1.Image;
                IntPtr icon = dragImage.GetHicon();
                Cursor.Current = new Cursor(icon);
                DoDragDrop(pictureBox1.Image, DragDropEffects.Copy);
                DestroyIcon(icon);
            }
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e) {
            e.UseDefaultCursors = false;
        }
        protected override void OnDragEnter(DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(Bitmap))) e.Effect = DragDropEffects.Copy;
        }
        protected override void OnDragDrop(DragEventArgs e) {
            var bmp = (Bitmap)e.Data.GetData(typeof(Bitmap));
            var pb = new PictureBox();
            pb.Image = (Bitmap)e.Data.GetData(typeof(Bitmap));
            pb.Size = pb.Image.Size;
            pb.Location = this.PointToClient(new Point(e.X - pb.Width/2, e.Y - pb.Height/2));
            this.Controls.Add(pb);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        extern static bool DestroyIcon(IntPtr handle);
    }
