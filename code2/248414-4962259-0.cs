        int handleRadius = 3;
        int mPointMoveInProgress = 0;
        Point mPoint1, mPoint2;
        public Form1()
        {
            InitializeComponent();
            mPoint1 = new Point(50, 50); // Set correct default values
            mPoint1 = new Point(50, 300); // Set correct default values
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw line
            e.Graphics.DrawLine(new Pen(Color.Black, 2), mPoint1, mPoint2);
            Rectangle rectangle;
            // Draw first handle
            rectangle = new Rectangle(mPoint1.X - handleRadius, mPoint1.Y - handleRadius, handleRadius * 2, handleRadius * 2);
            e.Graphics.FillRectangle(Brushes.White, rectangle);
            e.Graphics.DrawRectangle(Pens.Black, rectangle);
            // Draw second handle
            rectangle = new Rectangle(mPoint2.X - handleRadius, mPoint2.Y - handleRadius, handleRadius * 2, handleRadius * 2);
            e.Graphics.FillRectangle(Brushes.White, rectangle);
            e.Graphics.DrawRectangle(Pens.Black, rectangle);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine if a point is under the cursor. If so, declare that a move is in progress
            if (Math.Abs(e.X - mPoint1.X) < handleRadius && Math.Abs(e.Y - mPoint1.Y) < handleRadius) mPointMoveInProgress = 1;
            else if (Math.Abs(e.X - mPoint2.X) < handleRadius && Math.Abs(e.Y - mPoint2.Y) < handleRadius) mPointMoveInProgress = 2;
            else mPointMoveInProgress = 0;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mPointMoveInProgress == 1) // If moving first point
            {
                mPoint1.X = e.X ;
                mPoint1.Y = e.Y ;
                Refresh();
            }
            else if (mPointMoveInProgress == 2) // If moving second point
            {
                mPoint2.X = e.X ;
                mPoint2.Y = e.Y ;
                Refresh();
            }
            else // If moving in the PictureBox: change cursor to hand if above a handle
            {
                if (Math.Abs(e.X - mPoint1.X) < handleRadius && Math.Abs(e.Y - mPoint1.Y) < handleRadius) Cursor.Current = Cursors.Hand;
                else if (Math.Abs(e.X - mPoint2.X) < handleRadius && Math.Abs(e.Y - mPoint2.Y) < handleRadius) Cursor.Current = Cursors.Hand;
                else Cursor.Current = Cursors.Default;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Declare that no move is in progress
            mPointMoveInProgress = 0;
        }
