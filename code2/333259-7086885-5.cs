            var pictureBox1MouseDowns = Observable
                .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                    h => pictureBox1.MouseDown += h,
                    h => pictureBox1.MouseDown -= h);
            var pictureBox1MouseMoves = Observable
                .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                    h => pictureBox1.MouseMove += h,
                    h => pictureBox1.MouseMove -= h);
            var pictureBox1MouseUps = Observable
                .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                    h => pictureBox1.MouseUp += h,
                    h => pictureBox1.MouseUp -= h);
            var pictureBox1MouseDrags =
                from md in pictureBox1MouseDowns
                from mm in pictureBox1MouseMoves.TakeUntil(pictureBox1MouseUps)
                let dx = mm.EventArgs.Location.X - md.EventArgs.Location.X
                let dy = mm.EventArgs.Location.Y - md.EventArgs.Location.Y
                select new Point(dx, dy);
            var pictureBox1MouseDragMessages =
                from md in pictureBox1MouseDrags
                let f = "You've dragged ({0}, {1}) from your starting point"
                select String.Format(f, md.X, md.Y);
