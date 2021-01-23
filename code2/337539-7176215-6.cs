    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private PictureBox pictureBox1;
            private PictureBox pictureBox2;
            private Image imageToDraw = null;
            private float imageRotation = 0.0f;
            private PointF imageTranslation = new PointF();
            public Form1()
            {
                InitializeComponent();
                pictureBox1 = new PictureBox() { Top = 20, Left = 10, Width = 280, Height = 310, BorderStyle = BorderStyle.FixedSingle };
                pictureBox2 = new PictureBox() { Top = 20, Left = pictureBox1.Right + 10, Width = 280, Height = 310, BorderStyle = BorderStyle.FixedSingle };
                pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
                pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
                this.Controls.Add(pictureBox1);
                this.Controls.Add(pictureBox2);
                this.Controls.Add(new Label() { Text = "Left = translation only, Right = translation and rotation", Width = Width / 2 });
                this.ClientSize = new Size(pictureBox2.Right + 10, pictureBox2.Bottom + 10);
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
            }
            private void Form1_Activated(object sender, EventArgs e)
            {
                try
                {
                    imageToDraw = Image.FromFile("C:\\Map.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ensure C:\\Map.jpg exists!");
                }
            }
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (imageToDraw != null)
                    imageToDraw.Dispose();
            }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                const float MoveSpeed = 5.0f;
                switch (e.KeyCode)
                {
                    case Keys.Q:
                        imageRotation -= 1.0f;
                        break;
                    case Keys.E:
                        imageRotation += 1.0f;
                        break;
                    case Keys.Up:
                        imageTranslation = new PointF(imageTranslation.X - (float)Math.Sin(imageRotation / 180 * Math.PI) * MoveSpeed, imageTranslation.Y - (float)Math.Cos(imageRotation / 180 * Math.PI) * MoveSpeed);
                        break;
                    case Keys.Down:
                        imageTranslation = new PointF(imageTranslation.X + (float)Math.Sin(imageRotation / 180 * Math.PI) * MoveSpeed, imageTranslation.Y + (float)Math.Cos(imageRotation / 180 * Math.PI) * MoveSpeed);
                        break;
                    case Keys.Left:
                        imageTranslation = new PointF(imageTranslation.X - (float)Math.Cos(imageRotation / 180 * Math.PI) * MoveSpeed, imageTranslation.Y + (float)Math.Sin(imageRotation / 180 * Math.PI) * MoveSpeed);
                        break;
                    case Keys.Right:
                        imageTranslation = new PointF(imageTranslation.X + (float)Math.Cos(imageRotation / 180 * Math.PI) * MoveSpeed, imageTranslation.Y - (float)Math.Sin(imageRotation / 180 * Math.PI) * MoveSpeed);
                        break;
                }
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (imageToDraw != null)
                {
                    e.Graphics.ResetTransform();
                    Matrix transformMatrix = new Matrix();
                    transformMatrix.Translate(-imageTranslation.X, -imageTranslation.Y);
                
                    e.Graphics.Transform = transformMatrix;
                    e.Graphics.DrawImage(imageToDraw, Point.Empty);
                    transformMatrix = new Matrix();
                    transformMatrix.Translate(50, 50);
                    transformMatrix.RotateAt(-imageRotation, new PointF(20, 20));
                    e.Graphics.Transform = transformMatrix;
                    e.Graphics.DrawString("^", new Font(DefaultFont.FontFamily, 40), Brushes.Black, 0, 0);
                }
            }
            private void pictureBox2_Paint(object sender, PaintEventArgs e)
            {
                if (imageToDraw != null)
                {
                    e.Graphics.ResetTransform();
                    Matrix transformMatrix = new Matrix();
                    transformMatrix.Translate(-imageTranslation.X, -imageTranslation.Y);
                    transformMatrix.RotateAt(imageRotation, new PointF(pictureBox1.Width / 2 + imageTranslation.X, pictureBox1.Height / 2 + imageTranslation.Y));
                    e.Graphics.Transform = transformMatrix;
                    e.Graphics.DrawImage(imageToDraw, Point.Empty);
                }
            }
        }
    }
