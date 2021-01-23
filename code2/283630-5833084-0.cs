      public partial class Form1 : Form
            {
                bool canResize;
                int mX, mY;
                Rectangle rect = new Rectangle();
         
                public Form1()
                {
                    InitializeComponent();
                }
         
                private void Form1_Paint(object sender, PaintEventArgs e)
                {
                    e.Graphics.DrawRectangle(new Pen(Brushes.Purple, 2), rect);
                }
         
                private void Form1_MouseDown(object sender, MouseEventArgs e)
                {
                    canResize = true;
                    mX = e.X; mY = e.Y;
         
                    rect.Location = new Point(mX, mY);
                }
         
                private void Form1_MouseUp(object sender, MouseEventArgs e)
                {
                    canResize = false;
                }
         
                private void Form1_MouseMove(object sender, MouseEventArgs e)
                {
                    if (canResize)
                    {
                        if (mX < e.X)
                        {
                            rect.X = mX;
                            rect.Width = e.X - mX;
                        }
                        else
                        {
                            rect.X = e.X;
                            rect.Width = mX - e.X;
                        }
                        if (mY < e.Y)
                        {
                            rect.Y = mY;
                            rect.Height = e.Y - mY;
                        }
                        else
                        {
                            rect.Y = e.Y;
                            rect.Height = mY - e.Y;
                        }
                        this.Invalidate();
                    }
                }
            }
