    public partial class Form1 : Form
    {
        PointF mouseDown;
        
        float newX;
        float newY;
        float zoomFactor = 1.0F;
        
        public Form1()
        {
            InitializeComponent();
            mouseDown = new PointF(0F, 0F);
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(panel1_MouseMove);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics dc = e.Graphics;
            dc.SmoothingMode = SmoothingMode.AntiAlias;
                        
            dc.TranslateTransform(newX, newY);
                        
            dc.ScaleTransform(zoomFactor, zoomFactor, MatrixOrder.Prepend);
            
            Color lineColor = Color.FromArgb(200, 200, 200);
            Pen linePen = new Pen(lineColor,1*zoomFactor);
            dc.DrawLine(linePen, 100, 100, 200, 100);
            dc.DrawLine(linePen, 200, 100, 200, 200);
            dc.DrawLine(linePen, 200, 200, 100, 200);
            dc.DrawLine(linePen, 100, 200, 100, 100);
            dc.DrawLine(linePen, 100, 100, 200, 200);
            dc.DrawLine(linePen, 200, 100, 100, 200);
        }
        private void panel1_MouseDown(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            if (mouse.Button == MouseButtons.Right)
            {
                mouseDown = mouse.Location;
                mouseDown.X = mouseDown.X - newX;
                mouseDown.Y = mouseDown.Y - newY;
            }
        }
        private void panel1_MouseMove(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            if (mouse.Button == MouseButtons.Right)
            {
                PointF mousePosNow = mouse.Location;
                float deltaX = mousePosNow.X - mouseDown.X;
                float deltaY = mousePosNow.Y - mouseDown.Y;
                newX = deltaX;
                newY = deltaY;
                panel1.Invalidate();
                            
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            PointF mP = mouse.Location;
            if (e.Delta > 0)
            {
                if (zoomFactor >= 1 && zoomFactor <= 10)
                {
                    zoomFactor += 1F;
                    newX = newX - ((mP.X - newX) / (zoomFactor - 1));
                    newY = newY - ((mP.Y - newY) / (zoomFactor - 1));
                }
                else if (zoomFactor == 0.5)
                {
                    zoomFactor = zoomFactor * 2;
                    newX = newX - ((mP.X - newX) );
                    newY = newY - ((mP.Y - newY) );
                }
                else if (zoomFactor < 0.5)
                {
                    zoomFactor = zoomFactor * 2;
                    newX = newX - ((mP.X - newX) );
                    newY = newY - ((mP.Y - newY) );
                }
            }
            else if (e.Delta < 0)
            {
                if (zoomFactor >2)
                {
                    zoomFactor -= 1F;
                    newX = newX + (((mP.X - newX)) / (zoomFactor+1 ));
                    newY = newY + (((mP.Y - newY)) / (zoomFactor+1));
                }
                else if (zoomFactor == 2) {
                    zoomFactor -= 1F;
                    newX = newX + ((mP.X - newX)/2);
                    newY = newY + ((mP.Y - newY)/2);
                }else if(zoomFactor <= 1 && zoomFactor > 0.2)
                {
                    zoomFactor = zoomFactor / 2;
                    newX = newX + ((mP.X - newX) / 2);
                    newY = newY + ((mP.Y - newY) / 2);
                }
            }
                        
            panel1.Invalidate();
        }
    }
