        private void MouseDoubleClickEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoSomthing();
            } else if (e.Button == MouseButtons.Right)
            {
                DoSomethingElse();
            }
        }
