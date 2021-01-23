        public void MusicNote_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            this.MouseMove -= new MouseEventHandler(OnDrag);
        }
