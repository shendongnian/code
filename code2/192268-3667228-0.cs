    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.GiveFeedback += Form1_GiveFeedback;
        }
        void Form1_GiveFeedback(object sender, GiveFeedbackEventArgs e) {
            string txt = "Dragging text";
            SizeF sz;
            using (var gr = this.CreateGraphics()) {
                sz = gr.MeasureString(txt, this.Font);
            }
            using (var bmp = new Bitmap((int)sz.Width, (int)sz.Height)) {
                using (var gr = Graphics.FromImage(bmp)) {
                    gr.Clear(Color.White);
                    gr.DrawString(txt, this.Font, Brushes.Black, 0, 0);
                }
                bmp.MakeTransparent(Color.White);
                e.UseDefaultCursors = false;
                IntPtr hIcon = bmp.GetHicon();
                Cursor.Current = new Cursor(hIcon);
                DestroyIcon(hIcon);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            this.DoDragDrop("example", DragDropEffects.Copy);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        extern static bool DestroyIcon(IntPtr handle);
    }
