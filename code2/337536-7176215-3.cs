    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Image imageToDraw = null;
    
            private float imageRotation = 0.0f;
            private PointF imageTranslation = new PointF();
    
            public Form1()
            {
                InitializeComponent();
    
                this.ClientSize = new Size(640, 480);
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Size imageSize = ClientSize;
    
                if (imageToDraw != null)
                {
                    Matrix transformMatrix = new Matrix();
    
                    transformMatrix.Translate(-imageSize.Width / 2, -imageSize.Height / 2, MatrixOrder.Append);
                    transformMatrix.Rotate(imageRotation, MatrixOrder.Append);
                    transformMatrix.Translate(imageSize.Width / 2, imageSize.Height / 2, MatrixOrder.Append);
    
                    transformMatrix.Translate(imageTranslation.X, imageTranslation.Y, MatrixOrder.Append);
    
                    e.Graphics.Transform = transformMatrix;
    
                    e.Graphics.DrawImage(imageToDraw, ClientRectangle);
                }
            }
    
            private void Form1_Activated(object sender, EventArgs e)
            {
                Rectangle screenRect = Screen.GetBounds(Point.Empty);
                
                imageToDraw = new Bitmap(screenRect.Width, screenRect.Height);
    
                using (Graphics g = Graphics.FromImage(imageToDraw))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, screenRect.Size);
                }
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (imageToDraw != null)
                    imageToDraw.Dispose();
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.R:
                        imageRotation += 1.0f;
                        break;
                    case Keys.Up:
                        imageTranslation = new PointF(imageTranslation.X, imageTranslation.Y - 5);
                        break;
                    case Keys.Down:
                        imageTranslation = new PointF(imageTranslation.X, imageTranslation.Y + 5);
                        break;
                    case Keys.Left:
                        imageTranslation = new PointF(imageTranslation.X - 5, imageTranslation.Y);
                        break;
                    case Keys.Right:
                        imageTranslation = new PointF(imageTranslation.X + 5, imageTranslation.Y);
                        break;
                }
    
                Invalidate();
            }
        }
    }
