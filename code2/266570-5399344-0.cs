        public addNote = false;
        private void buttonAddNote_Click(object sender, EventArgs e)
        {
            if (!addNote)
                addNote = true;
            else addNote = false;
        }
        private void curveBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (addNote)
            {
                Cursor = Cursors.Cross;
            }
        }
        private void curveBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            addNote = false;
        }
