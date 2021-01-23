        public class TouchScrollHelper
        {
            private Point mouseDownPoint;
            private Panel parentPanel;
            /// <summary>
            /// pass in the panel you would like to be touch scrollable and it will be handled here.
            /// </summary>
            /// <param name="panel">The root panel you need to scroll with</param>
            public TouchScrollHelper(Panel panel)
            {
                parentPanel = panel;
                CreateScrollablePanel(panel);
            }
            private void CreateScrollablePanel(Control control)
            {
                control.MouseDown += MouseDown;
                control.MouseMove += MouseMove;
                foreach (Control children in control.Controls)
                    CreateScrollablePanel(children);
            }
            private void MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                    this.mouseDownPoint = Cursor.Position;
            }
            private void MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;
                Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);
                if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
                    return;
                Point currAutoS = parentPanel.AutoScrollPosition;
                parentPanel.AutoScrollPosition = new Point(Math.Abs(currAutoS.X) - pointDifference.X, Math.Abs(currAutoS.Y) - pointDifference.Y);
                mouseDownPoint = Cursor.Position; //IMPORTANT
            }
        }
